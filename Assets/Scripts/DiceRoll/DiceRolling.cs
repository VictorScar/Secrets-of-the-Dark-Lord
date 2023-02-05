using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRolling : MonoBehaviour
{
    [SerializeField] CupController cup;
    [SerializeField] DiceSceneUI sceneUI;
    [SerializeField] float powerMinThrow = 5;
    [SerializeField] float powerMaxThrow = 20;
    int diceValue = 0;
    bool isWasThrown = false;
    public bool IsResultObtained { get; private set; } = false;
    [SerializeField] Rigidbody rb;

    public event System.Action onThrowWasMade;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cup.onCupRolling += RollingDice;
        cup.onThrowComlete += Throw;
    }

    void Update()
    {
        if (isWasThrown && !IsResultObtained)
        {
            if (rb.velocity.sqrMagnitude <= 0.01)
            {
                diceValue = ObtainResult();
                if (diceValue > 0)
                {
                    sceneUI.ShowDiceValue(diceValue);
                    IsResultObtained = true;
                }
            }
        }
    }

    void RollingDice()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    void Throw()
    {
        Vector3 throwDirection = new Vector3(0, 0, Random.Range(powerMinThrow, powerMaxThrow));
        rb.isKinematic = false;
        rb.AddForce(throwDirection, ForceMode.Impulse);
        rb.AddTorque(throwDirection, ForceMode.Impulse);
        isWasThrown = true;
        onThrowWasMade?.Invoke();
    }

    void OnDestroy()
    {
        cup.onCupRolling -= RollingDice;
        cup.onThrowComlete -= Throw;
    }

    int ObtainResult()
    {
        Vector3[] directions = new Vector3[] { -transform.up, transform.forward, -transform.forward,
            transform.right, -transform.right, transform.up };

        for (int i = 0; i < directions.Length; i++)
        {
            Ray ray = new Ray(transform.position, directions[i]);
            if (Physics.Raycast(ray, 0.5f))
            {
                //Debug.Log(i + 1);
                return i + 1;
            }
        }
        //Debug.Log(0);
        return 0;
    }
}

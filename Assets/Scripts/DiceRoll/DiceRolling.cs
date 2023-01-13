using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRolling : MonoBehaviour
{
    [SerializeField] CupController cup;
    [SerializeField] float powerMinThrow = 5;
    [SerializeField] float powerMaxThrow = 20;
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
            if (rb.velocity.sqrMagnitude <= 0.1)
            {
                IsResultObtained = true;
                Debug.Log(IsResultObtained);
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

    private void OnDestroy()
    {
        cup.onCupRolling -= RollingDice;
        cup.onThrowComlete -= Throw;
    }
}

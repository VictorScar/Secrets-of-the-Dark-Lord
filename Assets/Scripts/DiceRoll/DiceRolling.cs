using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.DiceRoll
{
    public class DiceRolling : MonoBehaviour
    {
        [SerializeField] CupController cup;
        [SerializeField] DiceSceneUI sceneUI;
        [SerializeField] float powerMinThrow = 5;
        [SerializeField] float powerMaxThrow = 20;

        [SerializeField] Rigidbody rb;

        public event System.Action<int> onResultObtained;


        void Start()
        {
            cup.onShakingEnd += Throw;
        }

        void Throw()
        {
            rb.rotation = Random.rotation;
            Vector3 throwDirection = new Vector3(0, 0, Random.Range(powerMinThrow, powerMaxThrow));
            rb.isKinematic = false;
            rb.velocity = throwDirection;
            rb.AddTorque(throwDirection, ForceMode.Impulse);
            StartCoroutine(WatchingTheDice());
        }

        void OnDestroy()
        {
            cup.onShakingEnd -= Throw;
        }

        int ObtainResult()
        {
            Vector3[] directions = new Vector3[] {
            -transform.up,
            transform.forward,
            -transform.forward,
            transform.right,
            -transform.right,
            transform.up
        };

            for (int i = 0; i < directions.Length; i++)
            {
                Ray ray = new Ray(transform.position, directions[i]);
                if (Physics.Raycast(ray, 0.5f))
                {
                    return i + 1;
                }
            }

            return 0;
        }

        IEnumerator WatchingTheDice()
        {
            //Ожидаем остановки кубика
            yield return new WaitUntil(() => rb.IsSleeping());

            //Получение результата
            int diceValue = 0;

            yield return new WaitWhile(() =>
            {
                diceValue = ObtainResult();
                return diceValue == 0;
            });

            //наводим камеру и выводим результат
            onResultObtained?.Invoke(diceValue);
        }

        //[NaughtyAttributes.Button]
        private void Reset()
        {
            rb = GetComponent<Rigidbody>();
        }
    }
}
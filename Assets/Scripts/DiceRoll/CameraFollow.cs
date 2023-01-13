using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.DiceRoll
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] DiceRolling target;
        [SerializeField] float speed = 1f;
        [SerializeField] float offset = 5f;

        private void Start()
        {
            target.onThrowWasMade += StartFolowwing;
        }
        void StartFolowwing()
        {
            StartCoroutine(FollowTheDice());
        }

        IEnumerator FollowTheDice()
        {
            while (true)
            {
                transform.LookAt(target.transform);

                if (!target.IsResultObtained)
                {
                    transform.position = target.transform.position + new Vector3(0, 0, -offset);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position
                    + new Vector3(0, offset, 0), Time.fixedDeltaTime * speed);
                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}
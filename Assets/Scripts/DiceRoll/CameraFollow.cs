using UnityEngine;

namespace SODL.DiceRoll
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] DiceRolling target;
        [SerializeField] CupController cup;
        [SerializeField] float speed = 1f;
        [SerializeField] float offset = 5f;

        Vector3 offsetZ;
        Vector3 offsetY;

        bool isResultObtained = false;
        bool isFollowEnabled = false;

        private void Start()
        {
            cup.onShakingEnd += () => isFollowEnabled = true;
            target.onResultObtained += (diceValue) => isResultObtained = true;
            offsetZ = new Vector3(0, 0, -offset);
            offsetY = new Vector3(0, offset, 0);
        }

        private void FixedUpdate()
        {
            if (!isFollowEnabled)
            {
                return;
            }

            transform.LookAt(target.transform);

            if (!isResultObtained)
            {
                transform.position = target.transform.position + offsetZ;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    target.transform.position + offsetY,
                    Time.fixedDeltaTime * speed);
            }
        }
    }
}
using System;
using UnityEngine;

namespace SODL.DiceRoll
{
    public class CupController : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        public event Action onShakingEnd;

        void Update()
        {
            ShakeUpdate();
        }

        void ShakeUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                transform.Rotate(transform.forward, Input.GetAxis("Mouse X") * speed * Time.deltaTime);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                onShakingEnd?.Invoke();
                enabled = false;
            }
        }
    }
}
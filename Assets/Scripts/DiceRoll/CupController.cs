using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    bool isThrowEnd = false;
    public event Action onCupRolling;
    public event Action onThrowComlete;

    void Update()
    {
        if (!isThrowEnd)
        {
            ShakeUpdate();
        }
    }

    void ShakeUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(transform.forward, Input.GetAxis("Mouse X") * speed * Time.deltaTime);
            onCupRolling?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isThrowEnd = true;
            onThrowComlete?.Invoke();
            Debug.Log("Throw!");
        }
    }
}

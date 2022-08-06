using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Player target;
    float speed = 0.4f;
    void Start()
    {
        target = FindObjectOfType<Player>();
    }

    
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

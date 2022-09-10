using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Player target;
    [SerializeField] Transform findingEffectPosition;
    [SerializeField] new Camera camera;
    [SerializeField] float speed = 3f;

    public Camera Camera { get => camera;}
    public Transform FindingEffectPosition { get => findingEffectPosition; }

    private void Awake()
    {
        Game.Instance.PlayerCamera = this;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

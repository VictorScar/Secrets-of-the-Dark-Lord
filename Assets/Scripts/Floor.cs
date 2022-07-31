using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Cell
{
    [SerializeField] Material[] materials;
    [SerializeField] new Renderer renderer;
    void Start()
    {

        if (renderer !=null && materials != null && materials.Length > 0)
        {
            renderer.material = materials[Random.Range(0, materials.Length)];
        }


    }


}

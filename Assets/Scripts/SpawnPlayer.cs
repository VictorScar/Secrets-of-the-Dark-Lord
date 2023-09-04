using SODL.Cells;
using SODL.Character;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Map map;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cameraFollow;
    public Cell startCell;
    void Start()
    {
        startCell = map.cells[9,1];
        GameObject instancePlayer = Instantiate(player, new Vector3(startCell.transform.position.x, 0, startCell.transform.position.z), Quaternion.identity, map.transform);
        instancePlayer.GetComponent<Player>().startingCell = startCell;
        Instantiate(cameraFollow, instancePlayer.transform.position, Quaternion.identity);
    }

    
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Map map;
    [SerializeField] GameObject player;
    public Cell startCell;
    void Start()
    {
        startCell = map.cells[9,1];
        GameObject _player = Instantiate(player, new Vector3(startCell.transform.position.x, 0, startCell.transform.position.z), Quaternion.identity);
        _player.GetComponent<Player>().startingCell = startCell;
    }

    
 
}

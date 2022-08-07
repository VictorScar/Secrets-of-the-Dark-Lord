using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCell : Floor
{
    [SerializeField] Player playerPrefab;
    [SerializeField] CameraFollow cameraFollowPrefab;


    public override void Init(Map map)
    {
        base.Init(map);
        Player instancePlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        instancePlayer.startingCell = this;
        CameraFollow cameraFollowInstance = Instantiate(cameraFollowPrefab, instancePlayer.transform.position, Quaternion.identity);
        cameraFollowInstance.target = instancePlayer;
    }
}

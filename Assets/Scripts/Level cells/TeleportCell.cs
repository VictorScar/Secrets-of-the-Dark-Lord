using SODL.Character;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Cells
{
    public class TeleportCell : Floor
    {
        [SerializeField] Player playerPrefab;
        [SerializeField] PlayerCamera cameraFollowPrefab;


        public override void Init(Map map)
        {
            base.Init(map);
            Player instancePlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            instancePlayer.startingCell = this;
            PlayerCamera cameraFollowInstance = Instantiate(cameraFollowPrefab, instancePlayer.transform.position, Quaternion.identity);
            cameraFollowInstance.target = instancePlayer;
        }
    }
}
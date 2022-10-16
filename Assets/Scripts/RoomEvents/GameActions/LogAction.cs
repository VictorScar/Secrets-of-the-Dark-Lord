using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SODL.RoomEvents
{
    [Serializable]
    public class LogAction : IGameAction
    {
        public string message;
        public void Run()
        {
            Debug.Log(message);
        }
    }
}

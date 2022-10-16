using System.Collections.Generic;
using UnityEngine;

namespace SODL.RoomEvents
{
    public class RoomEventManager : MonoBehaviour
    {
        [SerializeField] private List<RoomEvent> roomEvents;

        public void StartRandomEvent()
        {
            int randomEvent = Random.Range(0, roomEvents.Count);
            roomEvents[randomEvent].Run();
            Debug.Log(roomEvents[randomEvent].name);
            roomEvents.RemoveAt(randomEvent);
        }
    }
}
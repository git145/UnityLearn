using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room CurrentRoom;

    private Dictionary<string, Room> _exitDictionary = new Dictionary<string, Room>();

    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < CurrentRoom.Exits.Length; i++)
        {
            _exitDictionary.Add(CurrentRoom.Exits[i].KeyString, CurrentRoom.Exits[i].ValueRoom);

            _controller.InteractionDescriptionsInRoom.Add(CurrentRoom.Exits[i].ExitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (_exitDictionary.ContainsKey(directionNoun))
        {
            CurrentRoom = _exitDictionary[directionNoun];

            _controller.LogStringWithReturn($"You head off to the {directionNoun}");

            _controller.DisplayRoomText();
        }
        else
        {
            _controller.LogStringWithReturn($"There is no path to the {directionNoun}");
        }
    }

    public void ClearExits()
    {
        _exitDictionary.Clear();
    }
}

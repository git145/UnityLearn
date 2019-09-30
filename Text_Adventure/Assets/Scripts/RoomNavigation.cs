using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room CurrentRoom;

    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < CurrentRoom.Exits.Length; i++)
        {
            _controller.InteractionDescriptionsInRoom.Add(CurrentRoom.Exits[i].ExitDescription);
        }
    }
}

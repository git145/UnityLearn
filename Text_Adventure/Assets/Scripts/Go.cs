﻿using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, 
        string[] separatedInputWords)
    {
        controller.RoomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }
}

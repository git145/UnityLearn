using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text DisplayText;

    public InputAction[] InputActions;

    [HideInInspector] public RoomNavigation RoomNavigation;

    [HideInInspector] public List<string> InteractionDescriptionsInRoom = new List<string>();

    private readonly List<string> _actionLog = new List<string>();

    private void Awake()
    {
        RoomNavigation = GetComponent<RoomNavigation>();
    }

    private void Start()
    {
        DisplayRoomText();

        DisplayLoggedText();
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", InteractionDescriptionsInRoom.ToArray());

        string combinedText = $"{RoomNavigation.CurrentRoom.Description}\n{joinedInteractionDescriptions}";

        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        _actionLog.Add($"{stringToAdd}\n");
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", _actionLog.ToArray());

        DisplayText.text = logAsText;
    }

    private void UnpackRoom()
    {
        RoomNavigation.UnpackExitsInRoom();
    }

    private void ClearCollectionsForNewRoom()
    {
        InteractionDescriptionsInRoom.Clear();

        RoomNavigation.ClearExits();
    }
}

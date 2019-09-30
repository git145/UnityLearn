using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    [TextArea]
    public string Description;

    public string RoomName;

    public Exit[] Exits;
}

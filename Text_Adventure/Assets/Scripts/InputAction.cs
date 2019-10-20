using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public string KeyWord;

    public abstract void RespondToInput(GameController controller, 
        string[] separatedInputWords);
}

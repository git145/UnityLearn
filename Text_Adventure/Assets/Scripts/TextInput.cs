using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField _inputField;

    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();

        _inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();

        _controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };

        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < _controller.InputActions.Length; i++)
        {
            InputAction inputAction = _controller.InputActions[i];

            if (inputAction.KeyWord == separatedInputWords[0])
            {
                inputAction.RespondToInput(_controller, separatedInputWords);
            }
        }

        InputComplete();
    }

    private void InputComplete()
    {
        _controller.DisplayLoggedText();

        _inputField.ActivateInputField();

        _inputField.text = null;
    }
}

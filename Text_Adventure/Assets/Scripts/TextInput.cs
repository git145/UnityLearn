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

    private void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();

        _controller.LogStringWithReturn(userInput);

        InputComplete();
    }

    private void InputComplete()
    {
        _controller.DisplayLoggedText();

        _inputField.ActivateInputField();

        _inputField.text = null;
    }
}

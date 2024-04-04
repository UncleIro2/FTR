using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    private void Start()
    {
        // Add listener to detect changes in input field
        inputField.onValueChanged.AddListener(HandleInputValueChanged);
    }

    private void HandleInputValueChanged(string text)
    {
        Debug.Log("Input changed: " + text);
    }
}


using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField passwordInputField;

    private string correctPassword = "1234";

    public void CheckPassword()
    {
        string enteredPassword = passwordInputField.text;

        if (enteredPassword == correctPassword)
        {
            SceneManager.LoadScene("VestskovenConfirmed");
        }
        else
        {
             SceneManager.LoadScene("FailedPassword");
        }
    }
}


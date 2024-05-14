
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyAction : MonoBehaviour
{
    void Update()
    {
       if(SceneManager.GetActiveScene().name == "EnterCode")
        {
            // Check if '1' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Perform the action when '1' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }

            // Check if '2' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Perform the action when '2' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }

            // Check if '3' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Perform the action when '3' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }

            // Check if '4' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                // Perform the action when '4' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }
            // Check if '5' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                // Perform the action when '5' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            } 
            // Check if '6' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                // Perform the action when '6' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }
            // Check if '7' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                // Perform the action when '7' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }
            // Check if '8' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                // Perform the action when '8' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }
            // Check if '9' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                // Perform the action when '9' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }
            // Check if '0' key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                // Perform the action when '0' key is pressed
                SoundMananger.instance.PlaySound(SoundEnum.bip);
            }
        }
       
      
    }


}





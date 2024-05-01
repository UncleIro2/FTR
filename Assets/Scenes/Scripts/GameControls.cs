
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
    }


}





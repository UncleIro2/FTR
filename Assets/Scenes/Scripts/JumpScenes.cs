using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour


{
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGuidlines()
    {
        SceneManager.LoadScene("Guidlines");
    }
    public void LoadGetReady()
    {
        SceneManager.LoadScene("GetReady");
    }
    public void LoadEnterCode()
    {
        SceneManager.LoadScene("EnterCode");
    }

}


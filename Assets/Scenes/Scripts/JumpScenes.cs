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
    public void LoadDifficulty()
    {
        SceneManager.LoadScene("Difficulty");
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadVestskovenConfirmed()
    {
        SceneManager.LoadScene("VestskovenConfirmed");
    }
    public void LoadPlayPublic()
    {
        SceneManager.LoadScene("PlayPublic");
    }
    public void LoadCommingWater()
    {
        SceneManager.LoadScene("CommingWater");
    }
    public void LoadCommingEarth()
    {
        SceneManager.LoadScene("CommingEarth");
    }
    public void LoadCommingTornado()
    {
        SceneManager.LoadScene("CommingTornado");
    }
}


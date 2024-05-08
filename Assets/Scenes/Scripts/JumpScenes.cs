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
        SoundMananger.instance.PlaySound(SoundEnum.fire);
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
        SoundMananger.instance.PlaySound(SoundEnum.correct);
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
    public void LoadMediumLevels()
    {

        SceneManager.LoadScene("MediumLevels");
    }
    public void LoadHardLevels()
    {

        SceneManager.LoadScene("HardLevels");
    }
    public void LoadEasyLevels()
    {

        SceneManager.LoadScene("EasyLevels");
    }
    public void LoadCommingEarth()
    {
        SoundMananger.instance.PlaySound(SoundEnum.earthquake);
        
        SceneManager.LoadScene("CommingEarth");
    }
    public void LoadCommingTornado()
    {
        SoundMananger.instance.PlaySound(SoundEnum.storm);
        
        SceneManager.LoadScene("CommingTornado");
    }
    public void FailedPassword()
    {
        SoundMananger.instance.PlaySound(SoundEnum.correct);
        SceneManager.LoadScene("FailedPassword");
    }
}
  



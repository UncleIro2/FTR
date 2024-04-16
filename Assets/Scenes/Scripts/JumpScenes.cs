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
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGuidlines()
    {
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("Guidlines");
    }
    public void LoadGetReady()
    {
        SoundMananger.instance.PlaySound(SoundEnum.fire);
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("GetReady");
    }
    public void LoadEnterCode()
    {
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("EnterCode");
    }
    public void LoadDifficulty()
    {
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("Difficulty");
    }
    public void LoadStart()
    {
        SoundMananger.instance.PlaySound(SoundEnum.start);
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("Start");
    }
    public void LoadVestskovenConfirmed()
    {
        SoundMananger.instance.PlaySound(SoundEnum.correct);
        SceneManager.LoadScene("VestskovenConfirmed");
    }
    public void LoadPlayPublic()
    {
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("PlayPublic");
    }
    public void LoadCommingWater()
    {
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("CommingWater");
    }
    public void LoadCommingEarth()
    {
        SoundMananger.instance.PlaySound(SoundEnum.earthquake);
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("CommingEarth");
    }
    public void LoadCommingTornado()
    {
        SoundMananger.instance.PlaySound(SoundEnum.storm);
        SoundMananger.instance.PlaySound(SoundEnum.klik);
        SceneManager.LoadScene("CommingTornado");
    }
}


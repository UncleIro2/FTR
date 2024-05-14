using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour


{

    public string load;

    void Start()
    {
    }
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
        SoundMananger.instance.PlaySound(SoundEnum.Background);
        SceneManager.LoadScene("GetReady");
    }
    public void LoadEnterCode()
    {

        SceneManager.LoadScene("EnterCode");
    }
    public void LoadDifficulty()
    {
        SoundMananger.instance.PlaySound(SoundEnum.Background);
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
    public void LoadFailedPassword()
    {
       
        SceneManager.LoadScene("FailedPassword");
    }
    public void LoadTutorialFireEscape()
    {
        SoundMananger.instance.StopAllSounds();
        GameManager.lastLevelSceneIndex = 11;
        SceneManager.LoadScene("TutorialFireEscape");
    }
    public void LoadVGAFireEscapeNEM()
    {
        SoundMananger.instance.StopAllSounds();
        GameManager.lastLevelSceneIndex = 18;
        SceneManager.LoadScene("VGAFireEscapeNEM");
    }
    public void LoadVGAFireEscapeSVÆR()
    {
        SoundMananger.instance.StopAllSounds();
        GameManager.lastLevelSceneIndex = 19;
        SceneManager.LoadScene("VGAFireEscapeSVÆR");
    }
    public void GoToPreviousScene()
    {
        SceneManager.LoadScene(GameManager.lastLevelSceneIndex);
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && load == "Win")
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("WinningScreen");
        }
        else if (player.gameObject.tag == "Player" && load == "Death")
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("DeathScreen");
        }
    }

}
  



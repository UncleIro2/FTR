using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour


{

    public string load;
    private int previousSceneIndex;

    void Start()
    {
        // Store the index of the current scene when the script starts
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
    public void LoadFailedPassword()
    {
       
        SceneManager.LoadScene("FailedPassword");
    }
    public void LoadTutorialFireEscape()
    {

        SceneManager.LoadScene("TutorialFireEscape");
    }
    public void GoToPreviousScene()
    {
        // Load the previous scene based on its index
        SceneManager.LoadScene(previousSceneIndex);
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && load == "Win")
        {
            SceneManager.LoadScene("WinningScreen");
        }
        else if (player.gameObject.tag == "Player" && load == "Death")
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

}
  



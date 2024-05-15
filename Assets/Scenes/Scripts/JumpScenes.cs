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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("QUITmenu");
        }
    }
    public void LoadSampleScene()
    {
        GameManager.lastLevelSceneIndex = 12;
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGuidlines()
    {
        GameManager.lastLevelSceneIndex = 1;
        SceneManager.LoadScene("Guidlines");
    }
    public void LoadGetReady()
    {
        GameManager.lastLevelSceneIndex = 3;
        SoundMananger.instance.PlaySound(SoundEnum.Fireplace);
        SceneManager.LoadScene("GetReady");
    }
    public void LoadEnterCode()
    {
        GameManager.lastLevelSceneIndex = 2;
        SceneManager.LoadScene("EnterCode");
    }
    public void LoadDifficulty()
    {
        GameManager.lastLevelSceneIndex = 4;
        SoundMananger.instance.PlaySound(SoundEnum.Fireplace);
        SceneManager.LoadScene("Difficulty");
    }
    public void LoadStart()
    {
        GameManager.lastLevelSceneIndex = 0;
        SoundMananger.instance.PlaySound(SoundEnum.Fireplace);
        SceneManager.LoadScene("Start");
    }
    public void LoadVestskovenConfirmed()
    {
        GameManager.lastLevelSceneIndex = 5;
        SoundMananger.instance.PlaySound(SoundEnum.correct);
        SceneManager.LoadScene("VestskovenConfirmed");
    }
    public void LoadPlayPublic()
    {
        GameManager.lastLevelSceneIndex = 6;
        SceneManager.LoadScene("PlayPublic");
    }
    public void LoadCommingWater()
    {
        GameManager.lastLevelSceneIndex = 7;
        SoundMananger.instance.PlaySound(SoundEnum.wave);
        SceneManager.LoadScene("CommingWater");
    }
    public void LoadMediumLevels()
    {
        GameManager.lastLevelSceneIndex = 17;
        SceneManager.LoadScene("MediumLevels");
    }
    public void LoadHardLevels()
    {
        GameManager.lastLevelSceneIndex = 15;
        SceneManager.LoadScene("HardLevels");
    }
    public void LoadEasyLevels()
    {
        GameManager.lastLevelSceneIndex = 14;
        SceneManager.LoadScene("EasyLevels");
    }
    public void LoadCommingEarth()
    {
        GameManager.lastLevelSceneIndex = 9;
        SoundMananger.instance.PlaySound(SoundEnum.earthquake);

        SceneManager.LoadScene("CommingEarth");
    }
    public void LoadCommingTornado()
    {
        GameManager.lastLevelSceneIndex = 8;
        SoundMananger.instance.PlaySound(SoundEnum.storm);

        SceneManager.LoadScene("CommingTornado");
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
    public void LoadFailedPassword()
    {
        GameManager.lastLevelSceneIndex = 10;
        SceneManager.LoadScene("FailedPassword");
    }
    public void LoadKommerSnart()
    {
        GameManager.lastLevelSceneIndex = 20;
        SceneManager.LoadScene("KommerSnart");
    }
    public void LoadDeathScreenElevator()
    {
        GameManager.lastLevelSceneIndex = 22;
        SceneManager.LoadScene("DeathScreenElevator");
    }
    public void LoadDeathScreenStairs()
    {
        GameManager.lastLevelSceneIndex = 23;
        SceneManager.LoadScene("DeathSceenStairs");
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
        if (player.gameObject.tag == "Player" && load == "DeathScreenIld")
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("DeathScreenIld");
        }

        if (player.gameObject.tag == "Player" && load == "DeathScreenElevator")
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("DeathScreenElevator");
        }

        if (player.gameObject.tag == "Player" && load == "DeathScreenStairs")
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("DeathScreenStairs");
        }
    }

}




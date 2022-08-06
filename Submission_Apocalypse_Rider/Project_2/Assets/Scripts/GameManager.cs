using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    public LevelFinish levelComplete;
    public MusicManager musicManager;
    public PlayerSFXManager playerSFXManager;

    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        musicManager.ChangeMusic("Lv_Start");
        musicManager.ChangeMusic("Lv_Main");
    }

    // Update is called once per frame
    void Update()
    {
        //for debugging and presentation
        //quick method to switch levels
        if (Input.GetKeyDown(KeyCode.Alpha1) && (sceneName == "Scene1"))
        {
            musicManager.ChangeMusic("Lv_End");
            playerSFXManager.PauseEngineSFX();
            //Pause();
            SceneManager.LoadScene("Scene2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && (sceneName == "Scene2"))
        {
            musicManager.ChangeMusic("Lv_End");
            SceneManager.LoadScene("Scene3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && (sceneName == "Scene3"))
        {
            musicManager.ChangeMusic("Lv_End");
            SceneManager.LoadScene("Scene4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && (sceneName == "Scene4"))
        {
            musicManager.ChangeMusic("Lv_End");
            Pause();
            SceneManager.LoadScene("Main Menu");//function named endGame()
        }
        else if (Input.GetKeyDown("p"))
        {
            Pause();
        }
    }
    // Functions to be added //
    //play() function: contain startup gui and start the timeScale
    //endLevel() function: GUI for proceeding to another level

    public void levelFinish()
    {
        if (levelComplete.levelFinish && (sceneName == "Scene1"))
        {
            musicManager.ChangeMusic("Lv_End");
            playerSFXManager.PauseEngineSFX();
            //Pause();
            SceneManager.LoadScene("Scene2");
        }
        else if(levelComplete.levelFinish && (sceneName == "Scene2"))
        {
            musicManager.ChangeMusic("Lv_End");
            SceneManager.LoadScene("Scene3");
        }
        else if (levelComplete.levelFinish && (sceneName == "Scene3"))
        {
            musicManager.ChangeMusic("Lv_End");
            SceneManager.LoadScene("Scene4");
        }
        else if (levelComplete.levelFinish && (sceneName == "Scene4"))
        {
            musicManager.ChangeMusic("Lv_End");
            //function named endGame()
        }
    }
    //Pause should not change between scenes
    public void Pause()
    {
        musicManager.ChangeMusic("Lv_End");
        playerSFXManager.PauseEngineSFX();
        Time.timeScale = 0f;
        //disable player
        player.enabled = false;

        SceneManager.LoadScene("Pause Screen", LoadSceneMode.Additive);
        //TO DO: Add pause menu and also play ambient music for pause
        Time.timeScale = 1f;
        player.enabled = true;
    }
}

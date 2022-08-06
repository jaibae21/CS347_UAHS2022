using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private AudioSource audioSource;

    public void ResumeButton()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        SceneManager.UnloadSceneAsync("Pause Screen");
    }

    public void RestartButton()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        SceneManager.UnloadSceneAsync("Pause Screen");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void PauseButton()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        SceneManager.UnloadSceneAsync("Pause Screen");
        SceneManager.LoadScene("Main Menu");
    }
}

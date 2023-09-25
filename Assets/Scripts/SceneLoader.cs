using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
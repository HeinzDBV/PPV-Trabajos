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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
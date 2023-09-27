
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class DeadScreen : MonoBehaviour
{
public GameObject deadScreen;
public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        deadScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0)
        {
            Invoke("PauseGame", 1f);
            
        }
    }

    public void PauseGame()
    {
        deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}

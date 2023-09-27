
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class DeadScreen : MonoBehaviour
{
public GameObject deadScreen;
public Animator Player;
public deathstate deathstate;
public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Animator>();
        deadScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0 || deathstate.isinDead)
        {
            Player.SetBool("isDead", true);
            Invoke("deadEnd", 1f);
        }
    }

    public void deadEnd()
    {
        deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}

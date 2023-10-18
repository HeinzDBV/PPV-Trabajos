using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    public GameObject Final;
    // Start is called before the first frame update
    void Awake()
    {
        Final.SetActive(false);
    }

}

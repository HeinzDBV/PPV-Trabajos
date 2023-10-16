using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform door;

    void Awake()
    {
        door.transform.localPosition =  new Vector3(-4.66f, -2f, -5.976f);
        door.transform.localRotation =  Quaternion.Euler(0f, 90f, 0f);
    }   
    void Update()
    {
        if(DialogueManager.doorint == true)
        {
            Debug.Log("True");
            door.transform.localPosition =  new Vector3(-4.66f, 0, -5.976f);
            door.transform.localRotation =  Quaternion.Euler(90f, 90f, 0f);
        }
    }
}

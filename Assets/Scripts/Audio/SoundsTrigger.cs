using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsTrigger : MonoBehaviour
{
    public AudioSource SonidoAnterior;
    public AudioSource SonidoNuevo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the current audio (if any)
            SonidoAnterior.Stop();
            // Play the new audio clip
            SonidoNuevo.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
     public PlayableDirector timeline;
     public Collider Collider2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            // Play the Timeline
            timeline.Play();
        }
        
        
        // StartCoroutine(NoActivar());
    }
    // IEnumerator NoActivar()
    // {
    //     yield return new WaitForSeconds(3f);
    //     Destroy(Collider2);
    //     Debug.Log("Waited for 3 seconds. Now I can do something.");
    // }
}

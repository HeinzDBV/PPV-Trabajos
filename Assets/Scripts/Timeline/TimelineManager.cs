using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
 public PlayableDirector timeline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            // Play the Timeline
            timeline.Play();
        }
    }

    // Add a method to skip the Timeline (e.g., if the player presses a key)
    public void SkipTimeline()
    {
        // Stop the Timeline
        timeline.Stop();
    }
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space)) // Adjust the key to your preference
    {
        SkipTimeline();
    }
    
}

}

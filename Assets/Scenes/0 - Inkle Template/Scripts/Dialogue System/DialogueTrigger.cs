using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public static int dialogueStartFrame;
    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
        {
            visualCue.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                int layerMask = 1 << LayerMask.NameToLayer("VisualCue");
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Obtener la posición del mouse en el mundo en 2D
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
                
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("VisualCue"))
                    {
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                        dialogueStartFrame = Time.frameCount;
                    }
                }
            }

        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}

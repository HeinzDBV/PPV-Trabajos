using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTriggerNoNpc : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    public void StartDialogueModeRemote()
    {
        
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    public void ContinueDialogueRemote()
    {
        DialogueManager.GetInstance().ContinueStory();
    }
}

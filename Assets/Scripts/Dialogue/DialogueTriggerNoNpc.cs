using Unity.VisualScripting;
using UnityEngine;

public class DialogueTriggerNoNpc : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake() 
    {
        Debug.Log(inkJSON);
    }
    public void StartDialogueModeRemote()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    public void ContinueDialogueRemote()
    {
        DialogueManager.GetInstance().ContinueStory();
    }

    public void ExitDialogueModeRemote() 
    {
        DialogueManager.GetInstance().ExitDialogueMode();
    }
}

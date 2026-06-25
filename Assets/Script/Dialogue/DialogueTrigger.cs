using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;
    public void StartDialogue()
    {
        DialogueManager.instance.StartDialogue(Dialogue);
    }
}
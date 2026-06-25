using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }
    public Queue<string> DialogueLines;

    public TMP_Text DialogueText;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }
    void Start()
    {
        DialogueLines = new Queue<string>();
    }

    void Update()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueLines.Clear();
        foreach (string line in dialogue.DialogueLines)
        {
            DialogueLines.Enqueue(line);
        }
        WriteLine();
    }
    public void WriteLine()
    {
        if (DialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }
        string CurLine = DialogueLines.Dequeue();
        DialogueText.text = CurLine;
    }

    void EndDialogue()
    {
        SceneManager.LoadScene("Start");
    }
}

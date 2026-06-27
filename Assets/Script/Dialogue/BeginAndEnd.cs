using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class BeginAndEnd : MonoBehaviour
{
    DialogueTrigger DTrigger;
    public Image BlackScreen;
    void Start()
    {
        DTrigger = GetComponent<DialogueTrigger>();
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        BlackScreen.DOFade(0f, 3f);
        yield return new WaitForSeconds(5f);
        BlackScreen.enabled = false;
        DTrigger.StartDialogue();
    }
}

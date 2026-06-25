using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TMP_Text cashText;
    private int cashCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCash()
    {
        cashCount = cashCount+100 ;
        cashText.text = "Cash: $    " + cashCount.ToString();
    }
}

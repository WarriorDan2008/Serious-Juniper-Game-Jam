using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TMP_Text cashText;
    private float cashTotal = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddCash(float cashAmount)
    {
        cashTotal += cashAmount;
        cashText.text = "Total Cash:   " + cashTotal.ToString();
    }

}

using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    public TMP_Text cashText;
    private float totalCash = 0;

    public static Money instance { get; private set; }

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
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey("Cash"))
        {
            Load();
        }
    }
    void Update()
    {
        cashText.text = "$" + totalCash.ToString();
    }
    public void Add(float cashAmount)
    {
        if (totalCash >= 0)
        {
            if (cashAmount > 0)
            {
                totalCash += cashAmount;
            }
        }
        else
        {
            totalCash = 0;
        }

    }
    public void Save()
    {
        PlayerPrefs.SetFloat("Cash", totalCash);
    }
    void Load()
    {
        totalCash = PlayerPrefs.GetFloat("Cash");
    }
}

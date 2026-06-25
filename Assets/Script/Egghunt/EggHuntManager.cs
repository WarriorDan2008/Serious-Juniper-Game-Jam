using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EggHuntManager : MonoBehaviour
{
    public Vector3 TerrainSize;
    public EggSO[] Egg;
    public GameObject EggPrefab;
    public int minAmountToSpawn, MaxAmountToSpawn;
    EggSO eggtoget;
    public SpriteRenderer wantedeggImage;
    void Awake()
    {
        StartCoroutine(Spawn());
        GenerateNewEgg();
    }
    IEnumerator Spawn()
    {
        int j = Random.Range(minAmountToSpawn, MaxAmountToSpawn);
        for (int i = 0; i < j; i++)
        {
            GameObject g = Instantiate(EggPrefab, new Vector3(Random.Range(0, TerrainSize.x -5f), 8, Random.Range(5, TerrainSize.z -5f)), Quaternion.identity);
            Egg e = g.GetComponent<Egg>();
            e.egg = Egg[Random.Range(0, Egg.Length)];
        }
        yield return null;
    }
    void GenerateNewEgg()
    {
        eggtoget = Egg[Random.Range(0, Egg.Length)];
        wantedeggImage.sprite = eggtoget.eggSprite;
    }

    public void InsertEgg(EggSO insertedEgg)
    {
        if(insertedEgg.eggIndex == eggtoget.eggIndex)
        {
            Money.instance.Add(Random.Range(5, 25));
            GenerateNewEgg();
        }
    }
}

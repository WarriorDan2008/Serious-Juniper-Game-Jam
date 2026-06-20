using UnityEngine;

[CreateAssetMenu(fileName = "WalkPoint")]
public class WalkPoints : ScriptableObject
{
    public Vector3 position;
    public bool occupied = false;

    void OnEnable()
    {
        occupied = false;
    }
}

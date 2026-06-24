using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ClockNumber")]

public class ClockNumber : ScriptableObject
{
    public float rotation;
    public string scene;
}
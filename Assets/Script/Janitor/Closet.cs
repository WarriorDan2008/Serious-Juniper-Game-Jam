using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    public ToolManager toolManager;
    public void Interact()
    {
        // Switching Tools
        if (toolManager.selectedTool > 1)
        {
            toolManager.selectedTool = 0;
        }
        else
        {
            toolManager.selectedTool++;
        }
    }
}

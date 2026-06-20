using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    public GameObject[] tools;
    public int selectedTool = 0;
    public AudioSource mopAudio;

    public float interactionRange;

    void Update()
    {
        // Switching tools
        switch (selectedTool)
        {
            case 0:
                tools[0].SetActive(true);
                tools[1].SetActive(false);
                tools[2].SetActive(false);
                break;
            case 1:
                tools[0].SetActive(false);
                tools[1].SetActive(true);
                tools[2].SetActive(false);
                break;
            case 2:
                tools[0].SetActive(false);
                tools[1].SetActive(false);
                tools[2].SetActive(true);
                break;
        }

        
        // Mop Controls
        if (selectedTool == 0)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
                {
                    if (hit.transform.CompareTag("Stain"))
                    {
                        hit.transform.TryGetComponent<Stain>(out Stain stain);
                        stain.Clean(selectedTool);
                    }
                }

                mopAudio.volume = 100f;
            }
            else
            {
                mopAudio.volume = 0f;
            }
        }
    }
}

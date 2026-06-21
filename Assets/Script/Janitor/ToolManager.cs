using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    public GameObject[] tools;
    public int selectedTool = 0;
    public AudioSource mopAudio;
    public AudioSource vacuumAudio;
    public AudioSource trashAudio;

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

        // Vacuum Controls
        if (selectedTool == 1)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
                {
                    if (hit.transform.CompareTag("Vacuumable"))
                    {
                        hit.transform.TryGetComponent<Vacuumable>(out Vacuumable vacuumable);
                        vacuumable.Vacuum(selectedTool);
                    }
                }

                vacuumAudio.volume = 100f;
            }
            else
            {
                vacuumAudio.volume = 0f;
            }
        }

        // Trash Bag Controls
        if (selectedTool == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
                {
                    if (hit.transform.CompareTag("Trash"))
                    {
                        hit.transform.TryGetComponent<Trash>(out Trash trash);
                        trash.Grab(selectedTool);

                        trashAudio.Play();
                    }
                }
            }
        }
    }
}

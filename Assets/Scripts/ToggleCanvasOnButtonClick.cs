using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvasOnButtonClick : MonoBehaviour
{
    public GameObject targetCanvas; // Reference to the target Canvas
    public List<GameObject> deactivateObjects;
    void Update()
    {
        MainMenu();
    }

    private void MainMenu()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            targetCanvas.SetActive(!targetCanvas.gameObject.activeSelf);
            if (targetCanvas.gameObject.activeSelf == true)
            {
                foreach (GameObject obj in deactivateObjects)
                {
                    if (obj != null) // Check for null references
                    {
                        obj.SetActive(false);
                    }
                }
            }
            
        }
    }
}

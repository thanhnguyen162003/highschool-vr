using UnityEngine;

public class ToggleCanvasOnButtonClick : MonoBehaviour
{
    public GameObject targetCanvas; // Reference to the target Canvas

    void Update()
    {
        MainMenu();
    }

    private void MainMenu()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Debug.Log("active" + targetCanvas.gameObject.activeSelf);
            targetCanvas.SetActive(!targetCanvas.gameObject.activeSelf);

        }
    }
}

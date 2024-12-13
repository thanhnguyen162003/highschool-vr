using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;  // Scene name to load

    // This method will be called when the button is clicked
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

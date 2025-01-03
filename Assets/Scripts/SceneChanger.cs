using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void LoadScene(string sceneToLoad)
    {
        if (SceneManager.GetActiveScene().name != sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }
}

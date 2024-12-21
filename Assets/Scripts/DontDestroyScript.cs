using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScript : MonoBehaviour
{
    private static DontDestroyScript instance; // Singleton instance
    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this GameObject persist
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return; // Important to prevent further execution in this instance
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded( Scene scene, LoadSceneMode mode)
    {  
        GameObject myObject = GameObject.Find("IntroduceHub");
        if (myObject != null)
        {
            myObject.SetActive(instance.isActiveAndEnabled);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetSceneByName("UIScene");

        if (!scene.isLoaded)
            SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
    }
}

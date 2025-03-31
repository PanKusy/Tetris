using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene scene;

    private void Awake()
    {
        if (!Application.isEditor)
        {
            scene = SceneManager.GetSceneByName("UIScene");

            if (!scene.isLoaded)
                SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
        }
    }
}

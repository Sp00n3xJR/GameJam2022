using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void ReloadScene()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();

        Debug.Log("Reloading scene " + CurrentScene.name);
        SceneManager.LoadScene(CurrentScene.name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void ReloadScene()
    {
        PlayerManager.ReloadScene();
    }
}

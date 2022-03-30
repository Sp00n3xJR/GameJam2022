using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    public int Health = 100;
    public int Points = 0;

    void Update()
    {
        if (Player != null)
        {
            if (Health <= 0)
            {
                Invoke(nameof(ReloadScene), 1f);
                Player.SetActive(false);
            }
        }
    }

    public static void ReloadScene()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();

        Debug.Log("Reloading scene " + CurrentScene.name);
        SceneManager.LoadScene(CurrentScene.name);
    }
}

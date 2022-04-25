using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level1")
        {
            Destroy(gameObject);
        }

        if (currentScene.name == "Level2")
        {
            Destroy(gameObject);
        }

        if (currentScene.name == "Level3")
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject EndUI;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.activeSelf)
        {
            if (Player != null)
            {
                EndUI.SetActive(true);
                Player.SetActive(false);
                StopAllCoroutines();
            }
        }
    }
}

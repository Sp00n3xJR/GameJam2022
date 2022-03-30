using UnityEngine;

public class KillField : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.activeSelf)
        {
            if (Player != null)
            {
                Player.GetComponent<PlayerManager>().Health = 0;
            }
        }
    }
}

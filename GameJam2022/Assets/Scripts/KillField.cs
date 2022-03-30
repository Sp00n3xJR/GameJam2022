using UnityEngine;

public class KillField : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject KillObject;
    
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

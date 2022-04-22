using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public Upgrade upgrades;
    public int UpgradeAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject Player = collision.gameObject;

            switch (upgrades)
            {
                case Upgrade.DoubleJumping:
                    Player.GetComponent<PlayerMovement>().DoubleJumping = true;
                    break;
                case Upgrade.Speed:
                    Player.GetComponent<PlayerMovement>().Speed += UpgradeAmount;
                    break;
                case Upgrade.JumpHeight:
                    Player.GetComponent<PlayerMovement>().JumpHeight.y += UpgradeAmount;
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    public enum Upgrade
    {
        Speed,
        JumpHeight,
        DoubleJumping
    }
}

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

            if (upgrades == Upgrade.DoubleJumping)
            {
                Player.GetComponent<PlayerMovement>().DoubleJumping = true;
            }
            else
            {
                if (upgrades == Upgrade.Speed)
                {
                    Player.GetComponent<PlayerMovement>().Speed += UpgradeAmount;
                }
                if (upgrades == Upgrade.JumpHeight)
                {
                    Player.GetComponent<PlayerMovement>().JumpHeight = new(0, UpgradeAmount);
                }
            }
            this.gameObject.SetActive(false);
        }
    }

    public enum Upgrade
    {
        Speed,
        JumpHeight,
        DoubleJumping
    }
}

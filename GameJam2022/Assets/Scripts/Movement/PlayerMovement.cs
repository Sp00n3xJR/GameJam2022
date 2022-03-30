using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int Speed;

    // Movement Upgrades
    public bool Jumping = false;
    public bool DoubleJumping = false;

    private int OrgJumpDelay;
    public int JumpDelay;
    public Vector2 JumpHeight;

    void Start()
    {
        OrgJumpDelay = JumpDelay;
        JumpDelay = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Jumping && Input.GetKeyDown(KeyCode.Space) & JumpDelay <= 0) // Jumping
        {
            rb2d.AddForce(JumpHeight, ForceMode2D.Impulse);
            JumpDelay = OrgJumpDelay;
            StartCoroutine(DecreaseDelay());
        }
    }

    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(MoveHorizontal, 0);

        rb2d.AddForce(movement * Speed);
    }

    private IEnumerator DecreaseDelay()
    {
        while (JumpDelay > 0)
        {
            yield return new WaitForSeconds(1);
            JumpDelay -= 1;
        }
    }
}

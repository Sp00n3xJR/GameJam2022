using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int Speed;

    // Movement Upgrades
    public bool Jumping = false;
    public bool DoubleJumping = false;

    private int OrgJumpDelay;
    private int Jumps;
    public int JumpDelay;
    public Vector2 JumpHeight;

    bool pressed = false;

    void Start()
    {
        OrgJumpDelay = JumpDelay;
        JumpDelay = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void Movement(InputAction.CallbackContext context)
    {
        pressed = true;

        bool canceled = context.canceled;
        if (canceled)
        {
            pressed = false;
        }
    }

    // InputAction is stupid and doesn't have a proper keyhold action so I have to do this BS.
    private void FixedUpdate()
    {
        while (pressed)
        {
            float MoveHorizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new(MoveHorizontal, 0);

            rb2d.AddForce(movement * Speed);
            break;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!DoubleJumping)
        {
            if (Jumping & JumpDelay <= 0)
            {
                rb2d.AddForce(JumpHeight, ForceMode2D.Impulse);
                JumpDelay = OrgJumpDelay;
                StartCoroutine(DecreaseDelay());
            }
        }
        else if (DoubleJumping)
        {
            if (Jumping & JumpDelay <= 0)
            {
                if (Jumps >= 2)
                {
                    rb2d.AddForce(JumpHeight, ForceMode2D.Impulse);
                    JumpDelay = OrgJumpDelay;
                    StartCoroutine(DecreaseDelay());
                }
                else
                {
                    rb2d.AddForce(JumpHeight, ForceMode2D.Impulse);
                    Jumps += 1;
                }
            }
        }
    }

    // When touching a tilemap object, reset jumps.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.activeSelf & col.gameObject.GetComponent<Tilemap>())
        {
            Jumps = 0;
            JumpDelay = 0;
        }
    }

    private IEnumerator DecreaseDelay()
    {
        while (JumpDelay > 0)
        {
            yield return new WaitForSeconds(1);
            JumpDelay -= 1;
        }
        Jumps = 0;
    }
}

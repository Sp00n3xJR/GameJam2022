using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int Speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(MoveHorizontal, 0);

        rb2d.AddForce(movement * Speed);
    }
}

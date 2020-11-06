using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public Joystick joystick;
    public float joystickHorizontalSens;
    public float horizontalForce;
    public float verticalForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (joystick.Horizontal > joystickHorizontalSens)
        {
            //move right
            rigidBody.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        else if (joystick.Horizontal < -joystickHorizontalSens)
        {
            //move left
            rigidBody.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        else
        {
            //idle
        }
    }
}

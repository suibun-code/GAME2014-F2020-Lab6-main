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
    public float joystickVerticalSens;
    public float horizontalForce;
    public float verticalForce;
    public Transform spawnPoint;

    public bool isGrounded = false;

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
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickHorizontalSens)
            {
                //move right
                rigidBody.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = false;
                animator.SetInteger("AnimState", 1);
            }
            if (joystick.Horizontal < -joystickHorizontalSens)
            {
                //move left
                rigidBody.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = true;
                animator.SetInteger("AnimState", 1);

            }
            if (joystick.Vertical > joystickVerticalSens)
            {
                //jump
                rigidBody.AddForce(Vector2.up * verticalForce * Time.deltaTime);
                animator.SetInteger("AnimState", 2);

            }
            if (joystick.Horizontal < joystickHorizontalSens && joystick.Horizontal > -joystickHorizontalSens)
            {
                //idle
                animator.SetInteger("AnimState", 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //respawn
        if (other.gameObject.CompareTag("DeathPlane"))
            transform.position = spawnPoint.position;
    }
}

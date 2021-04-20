using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    //Move Speed
    private float moveForce = 10f;

    [SerializeField]
    //Jump Speed
    private float jumpForce = 11f;

    //X Position Speed ( A,D Keys on Keyboard )
    private float movementX;

    //Player Prefab 2D Rigidbody
    private Rigidbody2D PlayerRB;

    //Check if player touches the ground or not
    private bool IsGrounded;

    //Ground Tag
    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Move()
    {
        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsGrounded = false;
            PlayerRB.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            Debug.Log("Landed");
            IsGrounded = true;
        }
    }
}

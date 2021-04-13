using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private float Speed = 6.5f;
    Rigidbody2D Rigid;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 move = new Vector2(0f, +Speed);
            Rigid.velocity = move;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 move = new Vector2(0f, -Speed);
            Rigid.velocity = move;
        }  
    }
}

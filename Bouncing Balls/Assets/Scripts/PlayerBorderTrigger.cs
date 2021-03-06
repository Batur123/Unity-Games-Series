using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerBorderTrigger : MonoBehaviour
{
    Rigidbody2D Ball;
    public GameObject BallGB;
    public Text P1Score;
    public Text P2Score;
    public static int Player1Score = 0, Player2Score = 0;

    decimal GetRandom()
    {
        System.Random random = new System.Random();
        var rndNumber = new decimal(random.NextDouble());
        rndNumber = rndNumber * 15 - 3;

        return rndNumber;
    }

    void AddForceBall(float XCord, float YCord)
    {
        var rndNumber = GetRandom();

        Vector2 v2 = Ball.velocity;
        v2.y = XCord;
        v2.x = YCord;
        Ball.velocity = v2;

        Ball.AddForce(new Vector2(Convert.ToSingle(rndNumber), Convert.ToSingle(5f)));
    }

    void Start()
    {
        P1Score.text = Player1Score.ToString();
        P2Score.text = Player2Score.ToString();

        Ball = GetComponent<Rigidbody2D>();

        //Ball Position
        Vector2 pos = transform.position;
        pos.x = -0.69f;
        pos.y = 0.06f;
        Ball.transform.position = pos;
        var rndNumber = GetRandom();


        Vector2 v2 = Ball.velocity;
        v2.y = 2f;
        v2.x = Convert.ToSingle(rndNumber * 3);
        Ball.velocity = v2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var rndNumber = GetRandom();

        if (collision.collider.tag == "Player2Trigger")
        {
            AddForceBall(5f, -11f);
        }
        if (collision.collider.tag == "Player1Trigger")
        {
            AddForceBall(5f, 11f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Border1")
        {
            Instantiate(BallGB);
            Destroy(BallGB);
            Player2Score++;

            int Temp = Convert.ToInt32(P2Score.text);
            Temp++;
            P2Score.text = Temp.ToString();
        }
        else if (collision.tag == "Border2")
        {
            Instantiate(BallGB);
            Destroy(BallGB);
            Player1Score++;

            int Temp = Convert.ToInt32(P1Score.text);
            Temp++;
            P1Score.text = Temp.ToString();
        }
    }
}

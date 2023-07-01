using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed;
    public Vector2 vel;
    public bool gameStarted;
    public ScoreManager scoreManager;
    public bool isEnd;
    public ScoreManager sm;
    public GameObject gameOver;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SendBallToRandomDirection();
        
    }

    private void SendBallToRandomDirection()
    {
       
        rb2D.velocity = GeneateRandomVectorWithout(true) * speed;
        vel = rb2D.velocity;
    }

    private Vector2 GeneateRandomVectorWithout(bool sholudReturnNormalized)
    {
        Vector2 newVelocity = new Vector2();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        newVelocity.x = shouldGoRight ? Random.Range(.7f, .3f) : Random.Range(-.7f, -.3f);
        newVelocity.y = shouldGoRight ? Random.Range(.7f, .3f) : Random.Range(-.7f, -.3f);
        

        if (sholudReturnNormalized)
        { 

        return newVelocity;

        }

        return newVelocity;
    }
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector2.Reflect(vel, collision.contacts[0].normal);
        vel = rb2D.velocity;
    }
    private void Update()
    {
        if (!(sm.rightScore == sm.winningScore || sm.leftScore == sm.winningScore))
        {

            if (Input.GetKey(KeyCode.Space) && isEnd == true)
            {
                SendBallToRandomDirection();
                isEnd = false;
            }
        }
        else
        {
            gameOver.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            scoreManager.IncrementLeftPlayerScore();
        }
        else if (transform.position.x < 0)
        {
            scoreManager.IncrementRightPlayerScore();
        }

        isEnd = true;
        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

}

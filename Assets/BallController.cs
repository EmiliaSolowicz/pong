using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb2D;
   


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity
    }

    
    void Update()
    {
        
    }
}

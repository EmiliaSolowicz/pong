using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;



    void Start()
    {

    }


    void Update()
    {

        GetPlayerInput(); 
    }
        
    public void GetPlayerInput()
    {
        if (Input.GetKey(upKey) && transform.position.y < 5)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;

        }
        if (Input.GetKey(downKey) && transform.position.y > -5) 
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}


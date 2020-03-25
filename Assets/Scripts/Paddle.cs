using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPaddleRange = 1f;
    [SerializeField] float maxPaddleRange = 15f;
    [SerializeField] public float length = 2;
    [SerializeField] float maxSlope = 0.43f;//debuggin purposes
    [SerializeField] float speed = 10.198f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosX = Input.mousePosition.x / Screen.width*screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePosX, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosX, minPaddleRange, maxPaddleRange);
        transform.position = paddlePos;
      //  Debug.Log(gameObject.transform.position.x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*  
        Rigidbody2D  rigidBody2D = GameObject.Find("Ball")
              .GetComponent<Rigidbody2D>();
          float L = length;
          float x = rigidBody2D.position.x - gameObject.transform.position.x;
          float slope = (1 - Math.Abs(2 * x / L * maxSlope));
          Debug.Log(slope);
          Vector2 velocity = new Vector2(Math.Sign(x), slope).normalized * speed;
          rigidBody2D.velocity = velocity;
         rigidBody2D.velocity = velocity;
         */
        Debug.Log("bam");
    }
}

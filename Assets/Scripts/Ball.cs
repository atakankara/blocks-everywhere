using DigitalRuby.LightningBolt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    Rigidbody2D rigidBody2D;
    Vector2 paddleToBall;
    [SerializeField] LightningBoltScript lightningBoltScript;
    bool hasStarted = false;
    int loopCounter;
    [SerializeField] float maxSlope = 0.43f;//debuggin purposes
    [SerializeField] float speed = 10.198f;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {
            lockBalltoPaddle();
            launchWithMouseClick();
        }
    }

    private void launchWithMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }

    private void lockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (rigidBody2D.velocity.y <= 0.2f   && rigidBody2D.velocity.y >= -0.2f) loopCounter++;
        if (loopCounter >= 3) loopBreaker();
        if (hasStarted&&collision.collider.tag != "imaginary")
        {
            GetComponent<AudioSource>().Play();
        }
        if (collision.collider == paddle) paddleBounce();


    }

    private void loopBreaker()     
    {
        GameObject.Find("SimpleLightningBoltPrefab").GetComponent<AudioSource>().Play();
        lightningBoltScript.StartPosition.x = 8f;
        lightningBoltScript.StartPosition.y = 12f;
        lightningBoltScript.EndPosition.x = rigidBody2D.position.x;
        lightningBoltScript.EndPosition.y = rigidBody2D.position.y;
        lightningBoltScript.Trigger();

        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 2);
        rigidBody2D.velocity = rigidBody2D.velocity.normalized * speed;
        loopCounter = 0;
    }

    private void paddleBounce()
    {
        Debug.Log("paddle bouncing");
        float L = paddle.length;
        float x = rigidBody2D.position.x - paddle.transform.position.x;
        float slope = Math.Sign(x) * (1 - Math.Abs(2 * x / L * maxSlope));
        Debug.Log(slope);
        Vector2 velocity = new Vector2(1, slope).normalized * speed;
        rigidBody2D.velocity = velocity;
    }
}
   
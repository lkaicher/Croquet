using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitBall : MonoBehaviour
{
    float power;
    Vector2 mousePos; //mousePos on screen
    Vector2 worldPos;
    Vector2 mousePosFromBall; //mousePos relative to ball
    [SerializeField] float capDistance;
    bool launchBall;
    bool ballMoving;
    [SerializeField] float tolerance; //The tolerance value to see whether or not the ball is moving.

    Rigidbody2D myRb;
    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePosFromBall = (Vector2) transform.position - worldPos;
        GetPower();
    }

    private void FixedUpdate()
    {
        checkBallMoving();
        Launch();
    }

    float GetPower()
    {
        if (Distance(mousePosFromBall) > capDistance) power = capDistance;
        else power = Distance(mousePosFromBall);
        return power;
    }

    float Distance(Vector2 vector)
    {
        return Mathf.Sqrt(Mathf.Pow(vector.x,2) + Mathf.Pow(vector.y,2));
    }

    void OnHit(InputValue value)
    {
        if (value.isPressed) launchBall = true;
    }

    void Launch()
    {
        if (ballMoving) return; //We only want the player to launch the ball when it is finished moving.
        if (launchBall)
        {
            Vector3 launchDir = Vector3.Normalize((Vector3)mousePosFromBall);
            Vector2 forceVector = GetPower() * launchDir;
            myRb.AddForce(forceVector, ForceMode2D.Impulse);
        }
        launchBall = false;
    }

    void checkBallMoving()
    {
        if (Mathf.Abs(myRb.velocity.x) < tolerance && Mathf.Abs(myRb.velocity.y) < tolerance) ballMoving = false;
        else ballMoving = true;
    }
}

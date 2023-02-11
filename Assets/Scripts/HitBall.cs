using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitBall : MonoBehaviour
{
    [SerializeField] float xVel;
    [SerializeField] float yVel;
    [SerializeField] float power;
    Vector2 mousePos;
    [SerializeField] Vector2 worldPos;
    [SerializeField] float capDistance;
    [SerializeField] bool launchBall;

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
        GetPower();
    }

    private void FixedUpdate()
    {
        Launch();
    }

    float GetPower()
    {
        if (Distance(worldPos) > capDistance) power = capDistance;
        else power = Distance(worldPos);
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
        if (launchBall)
        {
            Vector3 launchDir = Vector3.Normalize((Vector3)worldPos - transform.position);
            Vector2 forceVector = -GetPower() * launchDir;
            myRb.AddForce(forceVector, ForceMode2D.Impulse);
        }
        launchBall = false;
    }
}

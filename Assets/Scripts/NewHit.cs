using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHit : MonoBehaviour
{
    public float force = 10f;
    public Rigidbody2D rb;
    private LineRenderer trajectory;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private float distance;

    SpriteRenderer SR;

    [SerializeField]
    private GameObject ballSprite;

    [SerializeField]
    private Sprite stillSprite;
    [SerializeField]
    private Sprite movingSprite;



    private void Start()
    {
        SR = ballSprite.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        trajectory = gameObject.AddComponent<LineRenderer>();
        trajectory.widthMultiplier = 0.9f; // Thickness of the line
        trajectory.material = new Material(Shader.Find("Sprites/Default"));
        trajectory.startColor = Color.red;
        trajectory.endColor = Color.red;
        trajectory.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = startPoint - endPoint;
            distance = direction.magnitude;

            trajectory.enabled = true;
            trajectory.SetPosition(0, startPoint);
            trajectory.SetPosition(1, startPoint + direction);
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            trajectory.enabled = false;
             SR.sprite= movingSprite;
        }
        if (rb.velocity.magnitude <= 30) {
            rb.velocity = new Vector3(0,0,0);
            SR.sprite= stillSprite;
        } else {
            ballSprite.transform.Rotate(new Vector3(0, 0, -1 * rb.velocity.magnitude * Time.deltaTime ));
        }
    }

}

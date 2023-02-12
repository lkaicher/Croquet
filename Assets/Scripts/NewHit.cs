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
    [SerializeField]
    private GoalTurnManager goalManager;
    [SerializeField]
    private int player;
    [SerializeField]
    private int rollDirection;



    private void Start()
    {
        SR = ballSprite.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        trajectory = gameObject.AddComponent<LineRenderer>();
        trajectory.widthMultiplier = 3f; // Thickness of the line
        trajectory.material = new Material(Shader.Find("Sprites/Default"));
        trajectory.startColor = Color.red;
        trajectory.endColor = Color.red;
        trajectory.enabled = false;
    }

    private void Update()
    {
        if (goalManager.currentPlayer != player){
            if(rb.velocity.magnitude >= 30){
                ballSprite.transform.Rotate(new Vector3(0, 0, rollDirection * rb.velocity.magnitude * Time.deltaTime ));
            }
            return;
        }
        if (!goalManager.turnInProgress){
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
             goalManager.beginTurn();
        }
        }
        if (goalManager.turnInProgress && rb.velocity.magnitude <= 30) {
            rb.velocity = new Vector3(0,0,0);
            SR.sprite= stillSprite;
            goalManager.endTurn();
        } else {
            ballSprite.transform.Rotate(new Vector3(0, 0, rollDirection* rb.velocity.magnitude * Time.deltaTime ));
           
        }
    }

}

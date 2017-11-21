using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlls : MonoBehaviour {
    public GameController gameController;
    public int score;

    public bool grounded = true;
    public int ScoreValue = 1;
    public int jumpMax = 1;
    public float accel = 1.0F;
    public float dI = 0.1F;

    public float hMax = 10;
    public float vMin = -15;

    private Rigidbody2D movement;
    private int jumpCount = 0;
    public Text countText;
    public int count;
    public float hspeedLast = 0;


    // Use this for initialization
    void Start () {
        // Allows the object to be moved
        movement = GetComponent<Rigidbody2D>();
        //Finds an instance of GameController to bind the coin object to; should be moved to the coin's own script at a later date
        GameObject gameControllerObject = GameObject.FindWithTag("ScoreText");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

         count = 5;
        SetCountText();
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Coin")
        {
            Destroy(col.gameObject);
            count = count + 10;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    // Update is called once per frame
    void Update() {

        // Speed Caps
        if (movement.velocity.x > hMax)
            movement.velocity = new Vector2(hMax, movement.velocity.y);
        if (movement.velocity.x < -hMax)
            movement.velocity = new Vector2(-hMax, movement.velocity.y);
        if (movement.velocity.y < vMin)
            movement.velocity = new Vector2(movement.velocity.x, vMin);

        // Grounding
        if (movement.velocity.y == 0)
        {
            grounded = true;
            if (hspeedLast <= 0 && jumpCount < jumpMax)
                jumpCount += 1;
        }

        else
            grounded = false;


        // Comtrols
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && jumpCount >= 1)
        {
                jumpCount -= 1;
                movement.velocity = new Vector2(movement.velocity.x, 10);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            if (grounded)
                movement.velocity = new Vector2(0, 0);
            else
                movement.velocity = new Vector2(0, -20);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (grounded)
            {
                movement.velocity = new Vector2(movement.velocity.x + accel, movement.velocity.y);
            }
            else
            {
                movement.velocity = new Vector2(movement.velocity.x + dI, movement.velocity.y);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (grounded)
            {
                movement.velocity = new Vector2(movement.velocity.x - accel, movement.velocity.y);
            }
            else
            {
                movement.velocity = new Vector2(movement.velocity.x - dI, movement.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = new Vector2(0, 0);
            movement.velocity = new Vector2(0, 0);
        }

        hspeedLast = movement.velocity.y;

    }
}

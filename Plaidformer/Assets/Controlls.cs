using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    public bool grounded = true;
    public GameController gameController;
    public int ScoreValue = 1;
    public int jumpMax = 1;
    public float accel = 1.0F;
    public float dI = 0.1F;

    public float hMax = 10;
    public float vMin = -15;

    private Rigidbody2D movement;
    private int jumpCount = 0;


    // Use this for initialization
    void Start () {
        // Allows the object to be moved
        movement = GetComponent<Rigidbody2D>();
        //Finds an instance of GameController to bind the coin object to; should be moved to the coin's own script at a later date
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Collision Event
    void IsColliding (Collision2D col)
    {
        /*
        if (col.gameObject.name == "Coin")
        {
            gameController.AddScore(1);
        }
        */
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
            if (jumpCount < jumpMax)
                jumpCount = jumpMax;
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

    }
}

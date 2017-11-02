using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    public bool grounded = true;
    public GameController gameController;
    public int ScoreValue = 1;

    public float hMax = 10;
    public float vMin = -15;

    //public float speed;

    float hMove;
    float vMove;

    private Rigidbody2D movement;


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
        grounded = true;
        if (col.gameObject.name == "Floor")
        {
            grounded = true;
        }
        */
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
            grounded = true;
        else
            grounded = false;


        // Comtrols
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                grounded = false;
                movement.velocity = new Vector2(movement.velocity.x, 10);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            if (grounded)
                movement.velocity = new Vector2(0, 0);
            else
                movement.velocity = new Vector2(movement.velocity.x, -20);
        }
        
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && grounded == true)
            movement.velocity = new Vector2(movement.velocity.x + 1, movement.velocity.y);

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && grounded == true)
            movement.velocity = new Vector2(movement.velocity.x - 1, movement.velocity.y);

    }
}

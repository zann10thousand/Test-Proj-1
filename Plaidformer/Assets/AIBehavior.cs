using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour {

    private Rigidbody2D RB;
    private Collider2D col;
    private bool edge = false;
    private int xspeed;
    public static int range = 10;
    Vector2 velocity;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        xspeed = Random.Range(-range, range);
        RB.velocity = new Vector2(xspeed, 0);
	}


    // Update is called once per frame
    void Update () {
        if (col.gameObject.name == "floor" || col.gameObject.name == "floor(Clone)")
            edge = false;
        else
            edge = true;

        if (edge)
            RB.velocity = new Vector2(-(RB.velocity.x), 0);
		
	}
}

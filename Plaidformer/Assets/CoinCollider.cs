using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCollider : MonoBehaviour {

    public GameController gameController;
    public int score;
    public Text countText;
    public int count;

    // Use this for initialization
    void Start () {
        count = 5;
        //SetCountText();

    }
    /*void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Coin")
        {
            Destroy(col.gameObject);
            count = count + 10;
            SetCountText();
        }
    }*/
    /*void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }*/


    // Update is called once per frame
    void Update () {
		
	}
}

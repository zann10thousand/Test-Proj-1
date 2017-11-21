using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class CoinCollider : MonoBehaviour {
    
    public GameController gameController;
    public int score;
    public Text countText;
    public int count = 5;
    public string countString;
    // Use this for initialization
    void Start () {
        //SetCountText();
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "ColorCircle")
        {
            countString = countText.text;
            Int32.TryParse(countString, out count);
            count = count + 10;
            SetCountText();
            Destroy(gameObject);
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }


    // Update is called once per frame
    void Update () {
		
	}
}

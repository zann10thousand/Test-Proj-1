using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GUIText scoreText;
    public int score;



	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
        scoreText.text = "Score: 0";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddScore(int newScoreValue)
    {
       score += newScoreValue;
       UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

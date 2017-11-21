using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject Floor;
    public GameObject Coin;
    public GameObject Enemy;

    // Use this for initialization
    void Start () {
        // Creates floors
        Instantiate(Floor, new Vector3(10, 2, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(-10, 2, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(0, 6, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(15, 10, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(-15, 10, 0), Quaternion.identity);

        // Creates some coins to collect as well
        Instantiate(Coin, new Vector3(10, 5, 0), Quaternion.identity);
        Instantiate(Coin, new Vector3(-10, 5, 0), Quaternion.identity);
        Instantiate(Coin, new Vector3(0, 8, 0), Quaternion.identity);
        Instantiate(Coin, new Vector3(15, 12, 0), Quaternion.identity);
        Instantiate(Coin, new Vector3(-15, 12, 0), Quaternion.identity);

        // Creates some eminys
        Instantiate(Enemy, new Vector3(10, 5, 0), Quaternion.identity);
        Instantiate(Enemy, new Vector3(-10, 5, 0), Quaternion.identity);
        Instantiate(Enemy, new Vector3(0, 8, 0), Quaternion.identity);
        Instantiate(Enemy, new Vector3(15, 12, 0), Quaternion.identity);
        Instantiate(Enemy, new Vector3(-15, 12, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject Floor;

    // Use this for initialization
    void Start () {
        // Creates floors
        Instantiate(Floor, new Vector3(10, 2, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(-10, 2, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(0, 6, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(15, 10, 0), Quaternion.identity);
        Instantiate(Floor, new Vector3(-15, 10, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

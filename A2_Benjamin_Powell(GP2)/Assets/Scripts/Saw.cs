using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {

    public GameObject saw;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        saw.transform.Rotate(new Vector3(0f, 0f, 3f));
	}
}

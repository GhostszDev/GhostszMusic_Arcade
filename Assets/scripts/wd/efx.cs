using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efx : MonoBehaviour {

    float timer;

	// Use this for initialization
	void Start () {

        timer = 0.5f;
		
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(this.gameObject, timer);
		
	}
}

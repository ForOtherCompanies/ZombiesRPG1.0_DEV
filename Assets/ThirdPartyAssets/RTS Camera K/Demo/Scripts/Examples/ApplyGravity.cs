using UnityEngine;
using System.Collections;

public class ApplyGravity : MonoBehaviour {



	float gravity = 9.8f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GetComponent<Rigidbody>().AddForce (0, -gravity * GetComponent<Rigidbody>().mass, 0);
	}
}

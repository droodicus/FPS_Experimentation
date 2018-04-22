using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strafing_Movement : MonoBehaviour {

	public float speed = 1;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * 0.1f * speed);
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * 0.1f * speed);

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * 0.1f * speed);
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.forward * -0.1f * speed);
		
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {

	public GameObject camera;

	public float Force;

	public float xForce;
	public float yForce;

	public Rigidbody rb;

	public bool grounded;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		grounded = true;
	}

	public void ResetNetForce()	{
		rb.AddForce (rb.velocity * -1);
	}

	void OnCollisionEnter(Collision col)	{
		//ALSO NEED TO CHECK IF THE PLAYER'S "FEET" ARE WHAT IS TOUCHING THE SCENARYu
		if (col.gameObject.tag == "Scenary") {
			grounded = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.Euler (0, camera.GetComponent<Mouse_Look> ().currentYRot, 0);

		xForce = Input.GetAxis ("Horizontal") * Force * 0.1f;
		yForce = Input.GetAxis ("Vertical") * Force * 0.1f;

		transform.Translate(new Vector3(xForce, 0, yForce));
		//rb.AddForce(new Vector3(xForce, 0, yForce), ForceMode.Impulse);


		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene ("main");

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit();

	}
}

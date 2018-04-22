using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Grapple : MonoBehaviour {
	public GameObject grapple_hook;
	public GameObject camera;
	GameObject hook_fired;
	Vector3 pos;

	public bool on_CD = false;
	public float CD = 10;

	public bool pulling = false;

	public float speed = 10;
	public float pull_speed = 5f;
	private float step;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}

	void resetCD()	{
		on_CD = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			if (on_CD == false) {
				hook_fired = Instantiate (grapple_hook, transform.position + (transform.forward), Quaternion.Euler (camera.transform.forward)) as GameObject;
				hook_fired.GetComponent<Grapple_Hook> ().SetCaster (this.gameObject);
				hook_fired.GetComponent<Rigidbody>().AddForce(camera.transform.forward * speed, ForceMode.Impulse);
				Debug.Log ("SHOOTING GRAPPLE");
				on_CD = true;
				Invoke ("resetCD", CD);
			} 
			else
				Debug.Log ("GRAPPLE STILL ON CD");
		}

		if (pulling == true) {
			if (Vector3.Distance (hook_fired.transform.position, this.transform.position) > 3) {
				step = pull_speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards (transform.position, pos, step);
			} 
			else {
				pulling = false;
				rb.isKinematic = false;
				rb.useGravity = true;
				Destroy (hook_fired);
			}
		}

	}

	public void Pull(Vector3 p)	{
		pos = p;
		pulling = true;
		rb.isKinematic = true;
		rb.useGravity = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Hook : MonoBehaviour {
	public GameObject Caster;

	public bool attached = false;

	Rigidbody rb;

	//Initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}


	//Simply stops traveling and calls the casting player's Pull() function once it collides with terrain
	void OnCollisionEnter(Collision col)	{
		if (col.gameObject.tag == "Scenary") {
			Debug.Log ("HIT SCENARY");
			rb.velocity = Vector3.zero;
			attached = true;
			Caster.GetComponent<Shoot_Grapple> ().Pull (this.transform.position);
		} 
		else		
		{
			Destroy (this.gameObject);	
		}

	}

	public void SetCaster(GameObject c)	{
		Caster = c;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

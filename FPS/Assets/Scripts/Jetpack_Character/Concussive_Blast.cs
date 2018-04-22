using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussive_Blast : MonoBehaviour {
	public float max_knockback = 10;
	public float radius = 10;

	Rigidbody obj_rb;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col)	{
		Collider[] objsInRadius = Physics.OverlapSphere (transform.position, radius);
		int i = 0;

		while (i < objsInRadius.Length) {

			obj_rb = objsInRadius [i].gameObject.GetComponent<Rigidbody> ();

			if (obj_rb != null) {			
				float dist = Vector3.Distance (transform.position, objsInRadius [i].transform.position);
				Vector3 dir = objsInRadius[i].transform.position - transform.position;
				dir.Normalize ();
				obj_rb.AddForce (dir * (max_knockback * (1 - (dist / radius))), ForceMode.Impulse);
			}

			i++;
		}

		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

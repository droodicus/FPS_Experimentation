using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Projectile : MonoBehaviour {
	public float max_knockback = 3;
	public float radius = 3;

	public float max_damage = 30;

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision col)	{
		Collider[] objsInRadius = Physics.OverlapSphere (transform.position, radius);
		int i = 0;

		while (i < objsInRadius.Length) {

			if (this.gameObject.tag == "Blue") {
				if (objsInRadius [i].gameObject.tag == "Red") {
					float dist = Vector3.Distance (transform.position, objsInRadius [i].transform.position);
					Debug.Log (objsInRadius [i].gameObject.name + " is this far away: " + dist);
					objsInRadius [i].gameObject.GetComponent<Health> ().TakeDamage(Mathf.RoundToInt(max_damage * (1 - (dist / radius))));


					Vector3 dir = objsInRadius[i].transform.position - transform.position;
					dir.Normalize ();
					objsInRadius [i].gameObject.GetComponent<Rigidbody> ().AddForce (dir * (max_knockback * (1 - (dist / radius))), ForceMode.Impulse);
				}
			}
			else if (this.gameObject.tag == "Red") {
				if (objsInRadius [i].gameObject.tag == "Blue") {
					float dist = Vector3.Distance (transform.position, objsInRadius [i].transform.position);
					Debug.Log (objsInRadius [i].gameObject.name + " is this far away: " + dist);
					objsInRadius [i].gameObject.GetComponent<Health> ().TakeDamage(Mathf.RoundToInt(max_damage * (1 - (dist / radius))));


					Vector3 dir = objsInRadius[i].transform.position - transform.position;
					dir.Normalize ();
					objsInRadius [i].gameObject.GetComponent<Rigidbody> ().AddForce (dir * (max_knockback * (1 - (dist / radius))), ForceMode.Impulse);
				}
			}

			i++;
		}

		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscan_Shoot : MonoBehaviour {
	public int damage = 10;

	public float wall_dist;

	public GameObject[] Bullet_Holes;

	public GameObject camera;

	Vector3 hole_pos;
	public float hole_buffer = 0.5f;

	Ray ray;
	RaycastHit hit;

	AudioSource gunshot;

	// Use this for initialization
	void Start () {
		gunshot = GetComponent<AudioSource> ();
	}

	void Fire()	{
		gunshot.Play ();
		//draw a ray in direction this.transform.forward (maybe using range)
		ray = new Ray(transform.position, camera.transform.forward);


		//detect what the ray first intersects with
		if(Physics.Raycast(ray, out hit))	{
			//Debug.Log(hit.collider.name);

			//if the object hit has a "Health" component, call the object's Health script's TakeDamage(damage) function
			if(hit.collider.gameObject.GetComponent<Health>() != null)	{
				hit.collider.gameObject.GetComponent<Health>().TakeDamage(damage);

			}
			//OPTIONAL: if the object DOESN'T have a "Health" component, create a "bullet impact" object at the point of impact.
			else {

				int bullet_index = Random.Range (0, Bullet_Holes.Length);
				Instantiate (Bullet_Holes[bullet_index], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Fire ();
		}


	}
}

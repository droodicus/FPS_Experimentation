using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Set : MonoBehaviour {

	public int current_index = 0;

	public GameObject p;
	Component[] projectile_shoots;


	// Use this for initialization
	void Start () {
		
	}

	public void SetCharacter(int i)	{
		current_index = i;
		UpdateCharacter ();
	}

	void UpdateCharacter()	{
		p = GameObject.Find ("Player");
		projectile_shoots = p.GetComponents (typeof(Projectile_Shoot));


		//Pharah
		if (current_index == 0) {
			p.GetComponent<Jetpack> ().enabled = true;
			foreach (Projectile_Shoot ps in projectile_shoots) {
				ps.enabled = true;
			}
			p.GetComponent<Hitscan_Shoot> ().enabled = false;
			p.GetComponent<Shoot_Grapple> ().enabled = false;
		} 
		//Widowmaker
		else if (current_index == 1) {
			p.GetComponent<Jetpack> ().enabled = false;
			foreach (Projectile_Shoot ps in projectile_shoots) {
				ps.enabled = false;
			}
			p.GetComponent<Hitscan_Shoot> ().enabled = true;
			p.GetComponent<Shoot_Grapple> ().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
}

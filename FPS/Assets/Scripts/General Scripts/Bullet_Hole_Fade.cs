using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Hole_Fade : MonoBehaviour {

	public float lifespan = 5;
	public float fadeRate = 0.0001f;

	public bool fading;

	Color this_color;
	Color temp_color;

	void Start () {
		fading = false;
		Invoke ("FadeOut", lifespan);
	}


	void FadeOut()	{
		fading = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (fading == true) 
		{
			this_color = GetComponent<Renderer> ().material.color;
			if (this_color.a > 0) 
			{
				temp_color = this_color;
				temp_color.a -= fadeRate;
				GetComponent<Renderer> ().material.color = temp_color;
			} 
			else 
			{
				Destroy (transform.parent.gameObject);		
			}
		}
	}
}

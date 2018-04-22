using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Bar : MonoBehaviour {
	public GameObject g;
	public float max_value;
	public float current_value;

	// Use this for initialization
	void Start () {
		
		current_value = max_value;
	}

	// Update is called once per frame
	void Update () {
		//change X scale based on current_hp/max_hp

		this.transform.localScale = new Vector3((current_value/max_value), 1, 1);
	}
}

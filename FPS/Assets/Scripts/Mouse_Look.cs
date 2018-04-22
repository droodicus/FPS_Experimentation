using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour {

	public float sensitivity = 5f;
	public float xRot;
	public float yRot;
	public float currentXRot;
	public float currentYRot;
	public float xRotV;
	public float yRotV;
	public float lookSmoothDamp = 0.1f;


	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		xRot -= Input.GetAxis ("Mouse Y") * sensitivity;
		yRot += Input.GetAxis ("Mouse X") * sensitivity;

		xRot = Mathf.Clamp (xRot, -90, 90);

		currentXRot = Mathf.SmoothDamp (currentXRot, xRot, ref xRotV, lookSmoothDamp);
		currentYRot = Mathf.SmoothDamp (currentYRot, yRot, ref yRotV, lookSmoothDamp);

		transform.rotation = Quaternion.Euler(currentXRot, currentYRot, 0);
		
	}
}

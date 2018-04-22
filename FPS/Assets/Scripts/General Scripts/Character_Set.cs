using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Set : MonoBehaviour {
	public GameObject[] characterList;

	public Vector3 current_location;
	public Quaternion current_rotation;

	public int current_index = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void SetCharacter(int i)	{
		for (int j = 0; j < characterList.Length; j++) {
			characterList [j].SetActive (false);
		}

		characterList [i].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			if (current_index == 1) {
				current_location = characterList [1].transform.position;
				current_rotation = characterList [1].transform.rotation;
				characterList [0].SetActive (true);
				characterList[1].SetActive(false);
				characterList [0].transform.position = current_location;
				characterList [0].transform.rotation = current_rotation;
				current_index = 0;
			} 
			else {
				current_location = characterList [0].transform.position;
				current_rotation = characterList [0].transform.rotation;
				characterList [1].SetActive (true);
				characterList[0].SetActive(false);
				characterList [1].transform.position = current_location;
				characterList [1].transform.rotation = current_rotation;
				current_index++;
			}
		}
	}
}

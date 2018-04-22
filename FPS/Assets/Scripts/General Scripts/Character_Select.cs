using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Select : MonoBehaviour {
	public GameObject[] characterList;
	public int current_index;


	// Use this for initialization
	void Start () {
		current_index = 0;
		characterList = new GameObject[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			characterList [i] = transform.GetChild (i).gameObject;

			if (i == 0)
				characterList [i].SetActive (true);
			else
				characterList [i].SetActive (false);
		}
	}

	public void SelectOne()	{
		if (current_index != 0) {
			characterList [current_index].SetActive (false);
			characterList [0].SetActive (true);
			current_index = 0;
		}
	}

	public void SelectTwo()	{
		if (current_index != 1) {
			characterList [current_index].SetActive (false);
			characterList [1].SetActive (true);
			current_index = 1;
		}
	}

	public void SelectThree()	{
		if (current_index != 2) {
			characterList [current_index].SetActive (false);
			characterList [2].SetActive (true);
			current_index = 2;
		}
	}
	public void SelectFour()	{
		if (current_index != 3) {
			characterList [current_index].SetActive (false);
			characterList [3].SetActive (true);
			current_index = 3;
		}
	}



	public void Confirm()	{
		Debug.Log ("CONFIRMED");
		//given the current index


		//load the next level playing as the character corresponding to the "current_index"
	}

	// Update is called once per frame
	void Update () {

	}
}

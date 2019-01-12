using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character_Select : MonoBehaviour {
	public GameObject[] characterList;
	public GameObject Character_Manager;

	public Scene main_scene;

	public int current_index;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);

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
		Debug.Log ("CONFIRMED: " + current_index);
		//given the current index

		SceneManager.LoadScene("main");
	}

	void OnEnable()	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}


	void OnSceneLoaded(Scene main_scene, LoadSceneMode mode)	{
		if (main_scene.name == "main") { 
			Debug.Log ("WEW LADS");
			Character_Manager = GameObject.Find ("Character_Manager");
			Character_Manager.GetComponent<Character_Set> ().SetCharacter (current_index);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}

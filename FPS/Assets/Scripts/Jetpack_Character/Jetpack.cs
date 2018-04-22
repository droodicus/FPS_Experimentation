using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour {

	Rigidbody rb;

	//Identifies if the player jumps or floats when the space bar is pressed
	public bool grounded = true;

	public float jump_height = 5;

	//Magnitude of the force that is applied while holding down the spacebar
	public float thrust = 17;

	public float max_fuel = 100;
	float current_fuel;

	//Minimum amount of fuel required to float while space is held
	public float min_fuel_req = 1;

	//Rate at which fuel is spent while floating
	public float fuel_spending = 1;

	//Rate at which fuel is spent while not holding down the spacebar
	public float fuel_regen = 0.5f;

	//Amount of time after the time the space bar is released that the fuel will start regenerating
	public float fuel_CD = 0.33f;
	bool fuel_on_CD = false;

	//Magnitude of the force applied when using the shift ability
	public float shift_thrust = 20;
	bool shift_on_CD = false;


	//Cooldown for shift ability
	public float shift_CD = 5;

	//Used to display remaining cooldown on shift ability on the UI
	float time_shift_casted;
	float shift_remaining_CD = 0;

	public Image shift_CD_Bar;
	public Image fuel_bar;

	//Initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();
		current_fuel = max_fuel;

		fuel_bar = GameObject.Find ("Canvas/Fuel_Bar").GetComponent<Image> ();
		shift_CD_Bar = GameObject.Find ("Shift_Icon_CD").GetComponent<Image> ();
	}

	//If the player touches the floor, they are considered "grounded"
	void OnCollisionEnter(Collision col)	{
		if (col.gameObject.tag == "Floor")
			grounded = true;
	}

	//Simple jump function
	void Jump()	{
		grounded = false;
		rb.AddForce (Vector3.up * jump_height, ForceMode.Impulse);
	}

	//Function adds gradual upward force when the space bar is held and the player has sufficient fuel
	void ThrustUp()	{
		if (current_fuel > min_fuel_req) {
			grounded = false;
			fuel_on_CD = true;
			CancelInvoke ("RegenFuel");
			rb.AddForce (Vector3.up * thrust);
			current_fuel -= fuel_spending;
		} 
		//If the player tries floating with insufficient fuel, instead start regenerating the fuel after a brief delay
		else
			Invoke ("RegenFuel", fuel_CD);
	}

	//Simply toggle the fuel_on_CD boolean to allow the fuel to automatically regenerate in the Update() function
	void RegenFuel()	{
		fuel_on_CD = false;
	}

	//Resets the shift_on_CD boolean
	void ToggleShiftCD()	{
		shift_on_CD = false;
	}

	// Update is called once per frame
	void Update () {
		//Update the fuel gauge on the UI
		fuel_bar.fillAmount = current_fuel/max_fuel;

		if (Input.GetKey (KeyCode.Space)) {
			//If the player presses space from the ground, perform a normal jump
			if (grounded == true) {
				Jump ();
			} 
			//If the player presses space while in the air, instead use the jetpack's ThrustUp function
			else {
				ThrustUp ();
			}	
		} 

		//When the player lets go of the space bar, start regenerating fuel after a brief delay
		if (Input.GetKeyUp (KeyCode.Space)) {
			Invoke ("RegenFuel", fuel_CD);
		}

		//Regenerate fuel when appropriate
		if (fuel_on_CD == false) {
			if(current_fuel < max_fuel)
				current_fuel += fuel_regen;
		}

		//Pressing the left shift gives a burst of upward force (based on the shift_thrust variable)
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (shift_on_CD == false) {
				grounded = false;
				shift_on_CD = true;
				rb.velocity = Vector3.zero;
				rb.AddForce (Vector3.up * shift_thrust, ForceMode.Impulse);
				time_shift_casted = Time.time;

				//reset the shift_on_CD boolean on a timer based on the shift_CD variable
				Invoke ("ToggleShiftCD", shift_CD);
			}
		}

		//Update the Icon on the UI showing how much cooldown is left on the shift ability
		if (shift_on_CD == true) {
			shift_remaining_CD = shift_CD - (Time.time - time_shift_casted);
			shift_CD_Bar.fillAmount = shift_remaining_CD / shift_CD;
		}

	}
}

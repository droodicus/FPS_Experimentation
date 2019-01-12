using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoot_Grapple : MonoBehaviour {
	public GameObject grapple_hook;
	public GameObject camera;
	GameObject hook_fired;

	//Position of the grappling hook when it collides with scenary
	Vector3 pos;

	//Cooldown variables for grappling hook ability's cooldown
	public bool on_CD = false;
	public float CD = 10;

	//Whether or not the player is currently being pulled by a grappling hook
	public bool pulling = false;

	//Grappling hook object's travel speed
	public float speed = 10;

	//Speed at which the character is pulled toward the grappling hook
	public float pull_speed = 5f;

	//Character is pulled to the grappling hook using steps (based on pull_speed)
	private float step;

	//Used to display remaining cooldown on shift ability on the UI
	float time_casted;
	float remaining_CD = 0;


	private Rigidbody rb;

	public Image CD_Bar;

	//Initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		rb = this.gameObject.GetComponent<Rigidbody> ();
		CD_Bar = GameObject.Find ("Shift_Icon_CD").GetComponent<Image> ();
	}

	//Basic cooldown reset function
	void resetCD()	{
		on_CD = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Shoot grapple using G
		if (Input.GetKeyDown (KeyCode.G)) {
			if (on_CD == false) {
				Debug.Log ("SHOOTING GRAPPLE");
				if (hook_fired != null)
					Destroy (hook_fired);
				hook_fired = Instantiate (grapple_hook, transform.position + (transform.forward), Quaternion.Euler (camera.transform.forward)) as GameObject;
				hook_fired.GetComponent<Grapple_Hook> ().SetCaster (this.gameObject);
				hook_fired.GetComponent<Rigidbody>().AddForce(camera.transform.forward * speed, ForceMode.Impulse);
				on_CD = true;
				time_casted = Time.time;

				//Reset the cooldown of the grappling hook after a delay (based on CD)
				Invoke ("resetCD", CD);
			} 
			else
				Debug.Log ("REMAINING CD: " + remaining_CD);
		}

		//Once the Pull() function is called, move the character towards the grappling hook until it reaches a minimum distance (in this case 3)
		if (pulling == true) {
			if (Vector3.Distance (hook_fired.transform.position, this.transform.position) > 3) {
				step = pull_speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards (transform.position, pos, step);
			} 
			//Once the player is close enough to the grappling hook, reset the relevant variables to "let go" of the grappling hook
			else {
				pulling = false;
				rb.isKinematic = false;
				rb.useGravity = true;
				Destroy (hook_fired);
			}
		}

		if (on_CD == true) {
			remaining_CD = CD - (Time.time - time_casted);
			CD_Bar.fillAmount = remaining_CD / CD;
		}

	}

	//Starts the loop of the player moving towards grappling hook's position (called by the grappling hook's script)
	public void Pull(Vector3 p)	{
		pos = p;
		pulling = true;
		rb.isKinematic = true;
		rb.useGravity = false;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public float max_hp = 100;
	public float current_hp;

	GameObject HP_obj;
	public Image HP_Bar;
	public float uptime = 5;

	// Use this for initialization
	void Start () {
		HP_obj = transform.Find ("HP").gameObject;
		HP_obj.SetActive (false);
		current_hp = max_hp;
		HP_Bar = transform.Find ("HP/HP_Bar").GetComponent<Image> ();
	}

	void Hide()	{
		HP_obj.SetActive (false);
	}

	public void TakeDamage(int amount)	{
		Debug.Log (this.gameObject.name + " took this much damage: " + amount);
		current_hp -= amount;

		if (current_hp < 1) {
			Debug.Log (this.gameObject.name + " died!");
			Destroy (this.gameObject);
		}
		else {
			HP_obj.SetActive (true);
			HP_Bar.fillAmount = current_hp / max_hp;
			CancelInvoke ();
			Invoke ("Hide", uptime);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

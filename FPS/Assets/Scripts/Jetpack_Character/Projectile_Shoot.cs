using UnityEngine;
using System.Collections;

public class Projectile_Shoot : MonoBehaviour {

	public GameObject camera;
	public Mouse_Look cam_script;

    public GameObject player_bullet;
    public float bullet_speed;

    public string Button;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		cam_script = camera.GetComponent<Mouse_Look> ();
	}

    void Shoot()
    {
		Vector3 rot = new Vector3 (cam_script.xRot, cam_script.yRot, 0);
		GameObject proj = Instantiate(player_bullet, transform.position + (transform.forward), Quaternion.Euler(rot)) as GameObject;
		Debug.Log (camera.transform.forward);
		proj.GetComponent<Rigidbody>().AddForce(camera.transform.forward * bullet_speed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Button == " ")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Button == "a")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (Button == "b")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (Button == "c")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Button == "d")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (Button == "e")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (Button == "f")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if (Button == "g")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            if (Button == "h")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (Button == "i")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (Button == "j")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (Button == "k")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (Button == "l")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (Button == "m")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            if (Button == "n")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (Button == "o")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (Button == "p")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Button == "q")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (Button == "r")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Button == "s")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (Button == "t")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            if (Button == "u")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            if (Button == "v")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (Button == "w")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (Button == "x")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            if (Button == "y")
                Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Button == "z")
                Shoot();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (Button == "left")
                Shoot();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (Button == "right")
                Shoot();
        }
    }
}

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary_mobile{
	public float xMin,xMax,zMin,zMax;
}

public class PlayController_mobile : MonoBehaviour {
	
	public float tilt;
	public float speed;
	public Boundary_mobile boundary;
	
	public GameObject shot;
	public GameObject shotSpawn;
	public float fireRate;
	
	private float nextFire;
	
	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire=Time.time+fireRate;
			Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
			GetComponent<AudioSource>().Play();
		}
	}
	
	void FixedUpdate(){
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical=Input.GetAxis("Vertical");*/
		
		Vector3 movement = new Vector3 (Input.acceleration.x,0.0f,Input.acceleration.y);
		gameObject.GetComponent<Rigidbody> ().velocity = movement * speed;	
		gameObject.GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(gameObject.GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(gameObject.GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)
			);
		gameObject.GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f,0.0f,gameObject.GetComponent<Rigidbody> ().velocity.x*-tilt);
	}
}

using UnityEngine;
using System.Collections;

public class RollScream : MonoBehaviour {

	public float mSpeed;
	public float z;

	void Update () 
	{
		//Translate form right to left
		transform.Translate(Vector3.down * Time.deltaTime * mSpeed);
		// If first background is out of camera view,then show sencond background
		if(transform.position.z<=z)
		{
			//We can chenge this value to reduce the wdith between 2 background
			transform.position=new Vector3(transform.position.x,transform.position.y,-z);
		}
	}
}

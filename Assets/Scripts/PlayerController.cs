using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float m_speed = 15.0f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * m_speed;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * m_speed;
		transform.Translate (x, 0, z);

		Jump ();

	}

	void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			GetComponent<Rigidbody>().velocity = Vector3.up * m_speed;
		}
	}
}

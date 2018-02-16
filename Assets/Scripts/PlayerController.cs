using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float m_speed = 15.0f;
	private float m_jumpSpeed = 20.0f;
	private float m_horizontal;
	private float m_vertical;
	private bool  m_jump;

	private Rigidbody m_rigidBody;

	void Awake() 
	{
		m_rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * m_speed;
		m_vertical = Input.GetAxis ("Vertical") * Time.deltaTime * m_speed;
		transform.Translate (m_horizontal, 0, m_vertical);

		if (m_jump) {
			if (Input.GetKeyDown (KeyCode.Space)) {  // jump if on ground
				GetComponent<Rigidbody> ().velocity = Vector3.up * m_jumpSpeed;
			}
		}

	}

	void FixedUpdate()
	{
		if (gameObject.CompareTag("Block")) {
			m_jump = true;
		} 
		else {
			m_jump = false;
		}
	}


		
}

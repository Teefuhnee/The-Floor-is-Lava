using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	void OnTriggerEnter(Collider other) // destroy player if touch lava
	{
		if (other.gameObject.tag == "Player") 
		{
			Destroy (other.gameObject);
			GameController.m_alive = false;
		}
	}
}

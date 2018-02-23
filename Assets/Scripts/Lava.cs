using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	public AudioClip m_deathSound;
	private AudioSource m_source;

	void Awake()
	{
		m_source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other) // destroy player if touch lava
	{
		if (other.gameObject.tag == "Player") 
		{
			m_source.PlayOneShot(m_deathSound, 1F);

			Destroy (other.gameObject);
			GameController.m_alive = false;
		}
	}
}

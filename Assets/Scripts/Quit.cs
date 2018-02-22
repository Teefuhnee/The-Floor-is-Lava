using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

	public void ReturnTitle()
	{
		SceneManager.LoadScene("Start");
		Time.timeScale = 1;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour {

	public Transform m_controlsList;
	public Transform m_pauseMenu;
	public Transform m_colorBlocks;
	public Transform m_colorText;
	public Transform m_gameOverText;
	public Transform m_pauseButton;

	public void ViewControls()
	{
		m_controlsList.gameObject.SetActive (true);
		Time.timeScale = 0;

		m_pauseMenu.gameObject.SetActive (false);
		m_colorBlocks.gameObject.SetActive (false);
		m_colorText.gameObject.SetActive (false);
		m_gameOverText.gameObject.SetActive (false);
		m_pauseButton.gameObject.SetActive (false);
	}
}

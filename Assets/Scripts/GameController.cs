using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private string m_blockColor;
	private List<string> m_colorBlocks;
	public GameObjectBox blocks;
	private string blockColor;
	public TextBox textBox;
	private float m_speed = 30f;

	static public bool m_alive;
	static public bool m_finish;
	private int firstTime = 1;
	public Transform m_pauseMenu;
	public Transform m_controlsMenu;

	// Use this for initialization
	void Start () 
	{
		m_alive = true; // player is alive
		m_finish = false;
		m_colorBlocks = new List<string>
		{
			"Red",
			"Orange",
			"Yellow",
			"Green",
			"Blue",
			"SkyBlue",
			"Violet",
			"Pink",
			"Black"
		};
		textBox.colorText.text = "";
		textBox.gameOverText.text = "";
		blockColor = m_colorBlocks [Random.Range (0, m_colorBlocks.Count)];
		Debug.Log ("m_alive = " + m_alive + " m_finish = " + m_finish);
	}

	// Update is called once per frame
	void Update () 
	{
		if (firstTime == 1) {
			StartCoroutine (MoveBlocks ());
			--firstTime;
		}
		if (true == m_alive && true == m_finish) {
			blockColor = m_colorBlocks [Random.Range (0, m_colorBlocks.Count)];
			StartCoroutine (MoveBlocks ());
			m_finish = false;
		}
		if (false == m_alive) {
			textBox.gameOverText.text = "Game Over!";
			textBox.colorText.text = "";
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (m_pauseMenu.gameObject.activeInHierarchy == false) {
				m_pauseMenu.gameObject.SetActive (true);
				Time.timeScale = 0;
			}
			else {
				m_pauseMenu.gameObject.SetActive (false);
				Time.timeScale = 1;
			}
		}
	
	}
		
	IEnumerator MoveBlocks()
	{
		textBox.colorText.text = "";
		yield return new WaitForSeconds (1.5f);
		GameObject block; // randomly chosen block
		GameObject otherBlock;
		Rigidbody rigidBody; 

		block = GameObject.Find (blockColor);
		Debug.Log("Chosen block = " + block.name);
		textBox.colorText.text = block.name;

		for (int numBlocks = 0; numBlocks < 9; ++numBlocks) 
		{
			for (int index = 0; index < m_colorBlocks.Count; ++index)
				{
				otherBlock = GameObject.Find (m_colorBlocks[index]);

				rigidBody = otherBlock.GetComponent<Rigidbody> ();

				if (0 != string.Compare(m_colorBlocks[index], block.name))
					{
					int timer = 0;
					while (timer < 3) 
						{
						rigidBody.transform.Translate(Vector3.down * Time.deltaTime* m_speed);
						++timer;
						yield return null;
						}
					}
				}
		}
		yield return new WaitForSeconds (1);
		m_finish = true;

	}
		

	[System.Serializable]
	public class TextBox
	{
		public Text colorText;
		public Text gameOverText;
	}

	[System.Serializable]
	public class GameObjectBox
	{
		public GameObject Red;
		public GameObject Orange;
		public GameObject Yellow;
		public GameObject Green;
		public GameObject Blue;
		public GameObject SkyBlue;
		public GameObject Violet;
		public GameObject Pink;
		public GameObject Black;
	}
}
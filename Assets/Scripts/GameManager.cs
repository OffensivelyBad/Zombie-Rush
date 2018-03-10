using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject mainMenu;
	public static GameManager instance = null;
	private bool gameOver = false;
	private bool playerActive = false;
	private bool gameStarted = false;
	private int points = 0;

	public bool GameOver {
		get { return gameOver; }
	}
	public bool PlayerActive {
		get { return playerActive; }
	}
	public bool GameStarted {
		get { return gameStarted; }
	}
	public int Points {
		get { return points; }
	}

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (mainMenu);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerCollided() {
		gameOver = true;
	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

	public void StartGame() {
		mainMenu.SetActive (false);
		gameStarted = true;
	}

	public void ScoredPoint() {
		points += 1;
		print (points);
	}
}

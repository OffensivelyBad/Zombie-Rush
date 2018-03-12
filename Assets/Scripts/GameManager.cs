using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private Text scoreText;
	[SerializeField] private Player player;
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
		set {
			if (value) {
				Points = 0;
			}
		}
	}
	public int Points {
		get { return points; }
		set {
			points = value;
			scoreText.text = "Score: " + points;
		}
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
		Points = 0;
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
		Points = 0;
	}

	public void RestartGame() {
		mainMenu.SetActive (true);
		gameStarted = false;
		gameOver = false;
		playerActive = false;
		player.ResetToStartPosition ();
	}

	public void ScoredPoint() {
		Points += 1;
	}
}

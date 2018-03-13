using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Game objects
	[SerializeField] private List<PlatformObject> gameElements;
	[SerializeField] private Player player;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private Text scoreText;
	[SerializeField] private AudioClip sfxScore;
	private AudioSource audioSource;
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
		Assert.IsNotNull (sfxScore);
	}

	// Use this for initialization
	void Start () {
		Points = 0;
		scoreText.text = "";
		audioSource = GetComponent<AudioSource> ();
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

		// Reset the positions of the objects
		for (int i = 0; i < gameElements.Count; i++) {
			PlatformObject element = gameElements [i];
			element.ResetToInitialPosition ();
		}
		player.ResetToStartPosition ();
	}

	public void ScoredPoint() {
		Points += 1;
		audioSource.PlayOneShot (sfxScore);
	}
}

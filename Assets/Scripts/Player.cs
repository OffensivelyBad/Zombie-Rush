using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;
	[SerializeField] private float jumpForce = 120f;
	[SerializeField] private Vector3 startingPosition;
	private Animator anim;
	private Rigidbody rigidBody;
	private bool jump;
	private AudioSource audioSource;

	void Awake() {
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		ResetToStartPosition ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			if (Input.GetMouseButtonDown (0)) {
				if (!GameManager.instance.PlayerActive) {
					GameManager.instance.PlayerStartedGame ();
				}
				anim.Play ("Jump");
				audioSource.PlayOneShot (sfxJump);
				rigidBody.useGravity = true;
				jump = true;
			}
		} else if (GameManager.instance.GameOver && Input.GetMouseButtonDown(0) ) {
			GameManager.instance.RestartGame ();
		}

	}

	void FixedUpdate() {

		if (jump) {
			jump = false;
			rigidBody.velocity = new Vector2 (0, 0);
			rigidBody.AddForce (new Vector2 (0, jumpForce), ForceMode.Impulse);
		}

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "obstacle") {
			GameManager.instance.PlayerCollided ();
			rigidBody.AddForce (new Vector2 (-75, 35), ForceMode.Impulse);
			rigidBody.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeath);
		}
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag == "obstacle") {
			GameManager.instance.PlayerCollided ();
			rigidBody.AddForce (new Vector2 (-75, 500), ForceMode.Impulse);
			rigidBody.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeath);
		} 
	}

	public void ResetToStartPosition() {
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.Sleep ();
		rigidBody.detectCollisions = true;
		transform.localPosition = startingPosition;
	}

}

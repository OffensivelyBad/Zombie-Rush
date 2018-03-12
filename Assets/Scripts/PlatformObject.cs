using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour {

	[SerializeField] private float objectSpeed = 1.0f;
	[SerializeField] private float resetPosition = -29.5f;
	[SerializeField] private float startPosition = 42.62f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (!GameManager.instance.GameOver) {
			transform.Translate (Vector3.left * (objectSpeed * Time.deltaTime), Space.World);

			if (transform.localPosition.x < resetPosition) {
				ResetPosition ();
			}
		}
	}

	protected virtual void ResetPosition() {
		Vector3 newPosition = new Vector3 (startPosition, transform.position.y, transform.position.z);
		transform.position = newPosition;
	}

	public void ResetObject() {
		ResetPosition ();
	}
}

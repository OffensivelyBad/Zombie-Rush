using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	[SerializeField] private Vector3 topPosition;
	[SerializeField] private Vector3 bottomPosition;
	[SerializeField] private float objectSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Move (bottomPosition));
	}
	
	IEnumerator Move(Vector3 target) {

		while (Mathf.Abs ((target - transform.localPosition).y) > 0.2f) {
		
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * (Time.deltaTime * objectSpeed);

			yield return null;
		}

		yield return new WaitForSeconds (0.5f);

		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

		StartCoroutine (Move (newTarget));
	}
}

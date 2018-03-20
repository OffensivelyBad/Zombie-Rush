using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : PlatformObject {

    [SerializeField] private Vector3 topPosition = Vector3.zero;
    [SerializeField] private Vector3 bottomPosition = Vector3.zero;
	[SerializeField] private float speed = 1.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Move (bottomPosition));
	}

	protected override void Update ()
	{
		if (GameManager.instance.PlayerActive) {
			transform.Rotate (0, 50 * Time.deltaTime, 0);
			base.Update ();
		}
	}
	
	IEnumerator Move(Vector3 target) {

		while (Mathf.Abs ((target - transform.position).y) > 0.2f) {
		
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.position += direction * (Time.deltaTime * speed);

			yield return null;
		}

		yield return new WaitForSeconds (0.5f);

		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

		StartCoroutine (Move (newTarget));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PlatformObject {

	protected override void Update() {
		if (GameManager.instance.PlayerActive) {
			base.Update ();
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "player") {
			GameManager.instance.ScoredPoint ();
			ResetObject ();
		}
	}
}

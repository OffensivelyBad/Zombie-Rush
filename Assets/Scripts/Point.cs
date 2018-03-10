using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PlatformObject {

	protected override void Update() {
		if (GameManager.instance.PlayerActive) {
			base.Update ();
		}
	}
}

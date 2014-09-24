using UnityEngine;
using System.Collections;

public class SelectionCube : MonoBehaviour {

	void OnTriggerEnter (Collider coll) {
		if (coll.tag=="FriendlyUnit") {
			coll.GetComponent<OrderReceiver>().ToggleSelected();
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag=="FriendlyUnit") {
			coll.GetComponent<OrderReceiver>().ToggleSelected();
		}
	}
}

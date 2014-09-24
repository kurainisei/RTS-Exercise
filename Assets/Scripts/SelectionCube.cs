using UnityEngine;
using System.Collections;

public class SelectionCube : MonoBehaviour {

	private ClickManager _manager;

	void Start() {
		_manager = GetComponentInParent<ClickManager>();
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag=="FriendlyUnit") {
			OrderReceiver order = coll.GetComponent<OrderReceiver>();

			if (order.IsActive==false) {
				order.ToggleSelected();
				_manager.activeList.Add (coll.transform);
			}
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag=="FriendlyUnit") {
			OrderReceiver order = coll.GetComponent<OrderReceiver>();
			
			if (order.IsActive==true) {
				order.ToggleSelected();
				_manager.activeList.Remove (coll.transform);
			}

		}
	}
}

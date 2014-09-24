using UnityEngine;
using System.Collections;

public class ClickManager : MonoBehaviour {
	public Transform selectionCube;

	private bool _startDragging;
	private RaycastHit _hitInfo;
	private bool _hit;
	private Vector3 _startDragPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			_hitInfo = new RaycastHit();
			_hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo);
			if (_hit) {
				if (_hitInfo.collider.tag=="FriendlyUnit") {
					_hitInfo.collider.GetComponent<OrderReceiver>().ToggleSelected();
				}

				if (_hitInfo.collider.tag=="Ground") {
					_startDragPoint = _hitInfo.point;
					selectionCube.gameObject.SetActive(true);
				}
			}
		}

		if (Input.GetMouseButton(0)) {
			_hitInfo = new RaycastHit();
			_hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo);

			Vector3 midPoint = (_startDragPoint+_hitInfo.point)/2;

			selectionCube.position = new Vector3 (midPoint.x, 0.2f, midPoint.z);
			selectionCube.localScale = new Vector3 (_hitInfo.point.x-_startDragPoint.x, 0, _hitInfo.point.z-_startDragPoint.z);
		}

		if (Input.GetMouseButtonUp(0)) {
			selectionCube.gameObject.SetActive(false);
		}

	}


}

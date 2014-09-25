using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Units {
	public List<Transform> activeList = new List<Transform>();
}

public class ClickManager : MonoBehaviour {
	public Transform selectionCube;
	public List<Transform> activeList = new List<Transform>();
	private bool _startDragging;
	private RaycastHit _hitInfo;
	private bool _hit;
	private Vector3 _startDragPoint;
	private float _timer;
	private bool _movingOrder=false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			_hitInfo = new RaycastHit();
			_hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo);
			if (_hit) {
				_startDragPoint = _hitInfo.point;


				if (_hitInfo.collider.tag=="FriendlyUnit") {
					OrderReceiver order = _hitInfo.collider.GetComponent<OrderReceiver>();
					order.ToggleSelected();

					if (order.IsActive==true) {
						activeList.Add (_hitInfo.transform);
					}
					else {
						activeList.Remove (_hitInfo.transform);
					}
				}//Friendly Unit check

				if (_hitInfo.collider.tag=="Ground") {
					_movingOrder=true;
				}//Ground Click Check

			}//Hit Check

		}//MouseButtonDown Check

		if (Input.GetMouseButton(0)) {
			_timer+=Time.deltaTime;

			if (_timer>=0.2f) { //small delay before the selection cube actually appears
				_movingOrder=false;
				if (selectionCube.gameObject.activeInHierarchy==false)
				{
					selectionCube.gameObject.SetActive(true);
				}

				_hitInfo = new RaycastHit();
				_hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo);

				Vector3 midPoint = (_startDragPoint+_hitInfo.point)/2;

				selectionCube.position = new Vector3 (midPoint.x, 0.2f, midPoint.z);
				selectionCube.localScale = new Vector3 (_hitInfo.point.x-_startDragPoint.x, 0, _hitInfo.point.z-_startDragPoint.z);
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			selectionCube.gameObject.SetActive(false);
			_timer=0;
			if (_movingOrder) {
				int formationDimension = (int)Mathf.Sqrt(activeList.Count+2);
				foreach (Transform unit in activeList)
				{
					int rowNum = activeList.IndexOf(unit)/formationDimension;
					int colNum = activeList.IndexOf(unit)%formationDimension;
					float offset = 1.5f;
					unit.GetComponent<OrderReceiver>().MoveToPosition(new Vector3(_hitInfo.point.x+offset*rowNum, unit.position.y, _hitInfo.point.z+offset*colNum));
				}
				_movingOrder=false;
			}
		}

	}//update
	
}

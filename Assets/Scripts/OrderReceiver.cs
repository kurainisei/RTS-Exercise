using UnityEngine;
using System.Collections;

public class OrderReceiver : MonoBehaviour {
	public bool IsActive {
		get {
			return _isActive;
		}
	}

	public Color activeColor;
	public Color inactiveColor;

	private MovementManager _movement;
	private bool _isActive;

	// Use this for initialization
	void Start () {
		_isActive = false;
		_movement = GetComponent<MovementManager>();
	}

	public void ToggleSelected () {
		_isActive = !_isActive;

		if (_isActive) {
			renderer.material.color = activeColor;
		}

		else {
			renderer.material.color = inactiveColor;
		}
	}

	public void MoveToPosition (Vector3 target)
	{
		_movement.MoveToTarget(target);
	}
}

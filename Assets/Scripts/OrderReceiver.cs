using UnityEngine;
using System.Collections;

public class OrderReceiver : MonoBehaviour {
	public Color activeColor;
	public Color inactiveColor;

	private bool _isActive;

	// Use this for initialization
	void Start () {
		_isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	
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
}

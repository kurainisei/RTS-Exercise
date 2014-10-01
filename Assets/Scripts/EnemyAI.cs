using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private Transform _terrain;
	private MovementManager _movement;
	private float _timer=0;
	private bool _isEngaged=false;
	private float _stopTimer;
	// Use this for initialization
	void Start () {
		_movement = GetComponent<MovementManager>();
		_terrain = GameObject.FindWithTag("Ground").transform;
		_stopTimer = Random.Range(1,5);
	}
	
	// Update is called once per frame
	void Update () {
		if (_isEngaged) {

		}
		else {
			_timer+=Time.deltaTime;
			if (_timer >= _stopTimer) {
				float positionX = Random.Range ((int)_terrain.collider.bounds.min.x, (int)_terrain.collider.bounds.max.x);
				float positionZ = Random.Range ((int)_terrain.collider.bounds.min.z, (int)_terrain.collider.bounds.max.z);
				_movement.MoveToTarget(new Vector3(positionX, transform.position.y, positionZ));
				_timer=0;
				_stopTimer = Random.Range(1,5);
			}

		}
	}

	void ChangeBehavior() {

	}


}

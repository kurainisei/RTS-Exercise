using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {
	public bool isMoving;
	public float moveSpeed;

	public void MoveToTarget(Vector3 target) {
		if (isMoving)
		{
			StopMoving();
		}
		StartCoroutine (ReachTarget(target));
	}

	public void StopMoving() {
		StopAllCoroutines();
		isMoving=false;
	}
	
	IEnumerator ReachTarget(Vector3 target) {
		isMoving=true;
		while (transform.position != target)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
			yield return 0;
		}
	}
}

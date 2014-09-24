using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {

	public float moveSpeed;

	public void MoveToTarget(Vector3 target) {
		StopAllCoroutines();
		StartCoroutine (ReachTarget(target));
	}
	
	IEnumerator ReachTarget(Vector3 target) {
		while (transform.position != target)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
			yield return 0;
		}
	}
}

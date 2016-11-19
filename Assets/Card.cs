using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Card : MonoBehaviour {

	public void MoveToPosition (Vector3 position, Vector3 rotation, float moveTime) {
		transform.DOMove (position, moveTime, false);
		transform.DORotate (rotation, moveTime);
	}
}

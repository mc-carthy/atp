using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ScreenSwapper : MonoBehaviour {

	[SerializeField]
	private Transform board;
	private Vector3 boardOffScreenPos = new Vector3(0f, 10f, 0f);
	[SerializeField]
	private Transform menu;
	private Vector3 menuOffScreenPos = new Vector3(-20f, 0f, 0f);

	private float screenTransitionTime = 2f;

	public void MoveBoardOntoScreen () {
		board.DOMove (Vector3.zero, screenTransitionTime);
	}

	public void MoveBoardOffScreen () {
		board.DOMove (boardOffScreenPos, screenTransitionTime);
	}

	public void MoveMenuOntoScreen () {
		menu.DOMove (Vector3.zero, screenTransitionTime * 2);
	}

	public void MoveMenuOffScreen () {
		menu.DOMove (menuOffScreenPos, screenTransitionTime * 2);
	}
}

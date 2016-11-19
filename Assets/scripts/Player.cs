using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour {

	public Card cardToDraw;

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			DrawCardFromDrawDeck();
		}
	}

	private void DrawCardFromDrawDeck () {
		cardToDraw.MoveToPosition(transform.position, transform.localRotation.eulerAngles, 1.5f);
	}
}

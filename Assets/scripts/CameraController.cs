using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraController : MonoBehaviour {

	public void RotateToCurrentPlayer () {
		
		transform.DORotate(new Vector3(0, 0,CalculateZRotationForCurrentPlayer()), 1.5f);
	}

	private float CalculateZRotationForCurrentPlayer () {
		int numberOfPlayers = GameManager.Instance.NumberOfPlayers;
		int currentPlayer = GameManager.Instance.CurrentPlayer;

		float relativePlayerPosition = (float)currentPlayer / (float)(numberOfPlayers - 1);
		return relativePlayerPosition * 180 - 90;
	}
}

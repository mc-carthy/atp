using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	private Camera mainCam;

	private int numberOfPlayers = 3; // TODO - Hardcoded, to beread from menu selection
	public int NumberOfPlayers {
		get {
			return numberOfPlayers;
		}
	}

	private int currentPlayer = 1;
	public int CurrentPlayer {
		get {
			return currentPlayer;
		}
	}

	private void Awake () {
		MakeSingleton ();
		mainCam = Camera.main;
	}

	// TODO - Remove when finished testing
	private void Update () {
		if (Input.GetKeyDown(KeyCode.N)) {
			MoveToNextPlayer();
		}
	}

	private void MakeSingleton () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (Instance);
		} else {
			DestroyImmediate (gameObject);
		}
	}

	private void MoveToNextPlayer () {
		// Move to next player
		currentPlayer++;

		// If we were at the last player, move to first player
		if (currentPlayer >= numberOfPlayers) {
			currentPlayer = 0;
		}
		mainCam.GetComponent<CameraController> ().RotateToCurrentPlayer ();
	}
}

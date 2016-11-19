using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CardDealer : MonoBehaviour {

	private GameObject[] playerAreas;

	private int numberOfInitialRiders = 3;
	[SerializeField]
	private Transform drawDeckTransform;
	[SerializeField]
	private Card cardToDraw;

	private float dealSpeedInSeconds = 0.5f;
	private float dealIntervalInSeconds = 0.5f;

	private void Awake () {
		playerAreas = GameObject.FindGameObjectsWithTag ("Player");
	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine(DealRiderCards ());
		}
	}

	private IEnumerator DealRiderCards() {
		for (int i = 0; i < numberOfInitialRiders; i++) {
			foreach (GameObject pa in playerAreas) {
				Card newCard = Instantiate (cardToDraw, drawDeckTransform.position, drawDeckTransform.rotation) as Card;
				newCard.transform.SetParent (this.transform);
				Player p = pa.GetComponent<Player> ();
				newCard.transform.DOMove (p.handPos.transform.position, dealSpeedInSeconds);
				newCard.transform.DORotate (p.handPos.transform.rotation.eulerAngles, dealSpeedInSeconds);
				yield return new WaitForSeconds (dealIntervalInSeconds);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

/// <summary>
/// This script should be attached to the card game object to display card`s rotation correctly.
/// </summary>

[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class CardRotation : MonoBehaviour {

	// Parent game object for all the card face graphics
	public RectTransform CardFront;

	// Parent game object for all the card back graphics
	public RectTransform CardBack;

	// An empty game object that is placed a bit in front of the face of the card, in the center of the card
	public Transform targetFacePoint;

	// 3D box collider attached to the card
	public Collider col;

	// Players currently see the card Back
	private bool showingBack = false;

	void Update () 
	{
		// Raycast from Camera to a target point on the face of the card
		// If it passes through the card's collider, we should show the back of the card
		RaycastHit[] hits;
		hits = Physics.RaycastAll(origin: Camera.main.transform.position, 
			direction: (-Camera.main.transform.position + targetFacePoint.position).normalized, 
			maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude);
		bool passedThroughColliderOnCard = false;
		foreach (RaycastHit h in hits) {
			if (h.collider == col) {
				passedThroughColliderOnCard = true;
			}
		}

		if (passedThroughColliderOnCard != showingBack) {
			// Card flipped
			showingBack = passedThroughColliderOnCard;
			if (showingBack) {
				// Show the back side
				CardFront.gameObject.SetActive(false);
				CardBack.gameObject.SetActive(true);
			}
			else {
				// Show the front side
				CardFront.gameObject.SetActive(true);
				CardBack.gameObject.SetActive(false);
			}
		}
	}
}
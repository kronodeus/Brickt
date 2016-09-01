using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour {
	GameManager gameManager;

	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		gameManager.LoadLevel("Lose");
	}
}

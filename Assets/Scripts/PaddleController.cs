using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	Vector3 		paddlePosition;
	BallController 	ball;
	public bool 	autoPlay = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<BallController> ();
		paddlePosition = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if (autoPlay) {
			MoveWithAI ();
		} else {
			MoveWithMouse ();
		}
	}

	void MoveWithMouse () {
		paddlePosition.x = Mathf.Clamp (Input.mousePosition.x / Screen.width * 16, 1, 15);
		transform.position = paddlePosition;
	}

	void MoveWithAI () {
		paddlePosition.x = Mathf.Clamp(ball.transform.position.x, 1, 15);
		transform.position = paddlePosition;
	}
}

using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	public AudioClip 	bouncePaddle;
	public AudioClip 	bounceBrick;
	public AudioClip 	bounceWall;
	PaddleController 	paddle;
	Vector3 			paddleOffset;
	bool 				isDocked = true;
	string				lastObjectHit = "Paddle";
	GameManager			gameManager;

	// Use this for initialization
	void Start ()
	{
		gameManager = 	GameObject.FindObjectOfType<GameManager> ();
		paddle = 		GameObject.FindObjectOfType<PaddleController> ();
		paddleOffset = 	this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDocked) {
			transform.position = paddle.transform.position + paddleOffset;

			if (Input.GetMouseButtonDown (0)) {
				isDocked = false;
				LaunchBall();
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (!isDocked) {
			string currentObjectHit = col.collider.tag;
			if (lastObjectHit != "Paddle" && currentObjectHit == "Brick") {
				gameManager.BrickCombo ();
			} else if (currentObjectHit == "Paddle") {
				gameManager.EndCombo ();
			}
			RandomizeVelocity ();
			PlayHitSound (currentObjectHit);
			lastObjectHit = currentObjectHit;
		}
	}

	void LaunchBall ()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 10f);
	}

	void PlayHitSound (string hitObject)
	{
		switch (hitObject) {
		case "Brick":
			AudioSource.PlayClipAtPoint (bounceBrick, gameObject.transform.position);
			break;
		case "Paddle":
			AudioSource.PlayClipAtPoint (bouncePaddle, gameObject.transform.position);
			break;
		default:
			AudioSource.PlayClipAtPoint (bounceWall, gameObject.transform.position);
			break;
		}
	}

	void RandomizeVelocity ()
	{
		Vector2 velocityTweak = new Vector2 (Random.Range (-0.4f, 0.4f), 0f);
		GetComponent<Rigidbody2D> ().velocity += velocityTweak;
	}
}

using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	GameManager 		gameManager;
	SpriteRenderer 		spriteRenderer;
	public int			pointValue = 2;
	public GameObject 	burstFX;
	public int 			maxHits;
	int 				hits = 0;
	public Sprite[] 	hitSprites;

	// Use this for initialization
	void Start ()
	{
		gameManager = GameObject.FindObjectOfType<GameManager> ();
		gameManager.BrickCreated ();

		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionExit2D (Collision2D collision)
	{
		hits++;
		if (hits >= maxHits) {
			gameManager.BrickDestroyed (this);
			EmitBurst ();
			Destroy (gameObject);
		} else {
			UpdateSprite ();
		}
	}

	void UpdateSprite ()
	{
		int spriteIndex = Mathf.Clamp (hitSprites.Length - (maxHits - hits), 0, hitSprites.Length - 1);

		if (hitSprites [spriteIndex]) {
			spriteRenderer.sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing.");
		}
	}

	void EmitBurst ()
	{
		burstFX.GetComponent<ParticleSystem> ().startColor = spriteRenderer.color;
		Instantiate (burstFX, gameObject.transform.position, Quaternion.identity);
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
	public AudioClip 	brickDestroyedSound;
	public static int 	brickCount = 0;
	public static int 	multiplier = 1;
	public static int	points = 0;

	public void LoadLevel (string name)
	{
		brickCount = 0;
		multiplier = 1;
		points = 0;
		SceneManager.LoadScene (name);
	}

	public void RequestQuit ()
	{
		Application.Quit ();
	}

	public void BrickCreated ()
	{
		brickCount++;
	}

	public void BrickDestroyed (Brick brick)
	{
		brickCount--;
		points += brick.pointValue * multiplier;
		AudioSource.PlayClipAtPoint (brickDestroyedSound, brick.gameObject.transform.position);
		if (brickCount <= 0) {
			LoadLevel ("Win");
		}
	}

	public void BrickCombo ()
	{
		multiplier++;
	}

	public void EndCombo ()
	{
		multiplier = 1;
	}
}

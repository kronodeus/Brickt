using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStats : MonoBehaviour {
	public Text points;
	public Text brickCounter;
	public Text multiplier;
	
	// Update is called once per frame
	void Update () {
		points.text =		"Points: " + GameManager.points.ToString ();
		brickCounter.text = "Bricks Left: " + GameManager.brickCount.ToString ();
		multiplier.text =	"x" + GameManager.multiplier.ToString ();
	}
}

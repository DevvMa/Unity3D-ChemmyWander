using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour {


	public static float currentScore;
	//public AudioClip scorePick;
	public Text scoreField;

	bool scorePicked;
	bool trapPicked;
	// Use this for initialization
	void Start () {
		currentScore = 0;
		scoreField.text = currentScore.ToString();
		scorePicked = false;
		trapPicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (scorePicked || trapPicked) {
			scoreField.text = currentScore.ToString();	
		}

		scorePicked = false;
	}

	public void addScore(float score){
		scorePicked = true;
		currentScore += score;
	}
	public void remScore(float score){
		trapPicked = true;
		currentScore -= score;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    private int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
	}

    public void ScoreHit (int scorePerHit) {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
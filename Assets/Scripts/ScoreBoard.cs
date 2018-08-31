using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerHit = 10;
    private int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
	}

    public void ScoreHit() {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
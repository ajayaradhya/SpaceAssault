using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    TMPro.TextMeshProUGUI scoreText;
    int score = 0;

    // Use this for initialization
    void Start ()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = score.ToString();
	}
	
	public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}

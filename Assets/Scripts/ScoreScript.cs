
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    // public Transform player;
    public Text scoreText;
    public Text livesText;
    public static int ScoreValue = 0;
    public static int NumLives = 3;
    // public float prevPosition;

    private void Start() {
        scoreText.text = ScoreValue.ToString();
        livesText.text = NumLives.ToString();
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = ScoreValue.ToString();
        livesText.text = NumLives.ToString();
    }
    
    
    
}

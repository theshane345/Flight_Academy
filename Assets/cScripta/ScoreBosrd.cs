using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBosrd : MonoBehaviour
{
    
    int score;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int scoreInc)
    {
        score = score + scoreInc;
        scoreText.text = score.ToString();

    }

    public void DeathHit(int scoreDec)
    {
        score = score - scoreDec;
        scoreText.text = score.ToString();

    }



}

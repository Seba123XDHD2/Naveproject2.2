using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text Scoretext;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateScore()
    {
        Scoretext.text = "Score: " + score;
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int AddScore(int addScore)
    {
        score += addScore;
        return score;
    }

    public int GetScore()
    {
        return score;
    }
}

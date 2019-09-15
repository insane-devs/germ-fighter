using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = string.Format("High Score: {0}\nBest Wave: {1}", PlayerPrefs.GetInt("highscore", 0), PlayerPrefs.GetInt("bestwave", 0));
    }
}

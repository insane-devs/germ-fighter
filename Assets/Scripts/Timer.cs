using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerLabel;

    public float totalTime;

    private float time;
    private int wave;

    // Start is called before the first frame update
    void Start()
    {
        time = totalTime;
        wave = 1;
        timerLabel = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            time = totalTime;
            wave += 1;
            GameObject.Find("Plane").GetComponent<GermSpawner>().SpawnGerms();
            FindObjectOfType<PlayerScoreManager>().AddScore(100);
        };
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        float fraction = (time * 100) % 100;

        timerLabel.text = string.Format("Wave {3} - {0:00}:{1:00}.{2:000}", minutes, seconds, fraction, wave);
    }
}

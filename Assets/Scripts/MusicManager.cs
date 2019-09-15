using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Ambience>().PlayMusic();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("mute", 0) == 0) AudioListener.volume = 1;
        else AudioListener.volume = 0;
    }
}

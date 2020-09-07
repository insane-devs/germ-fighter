using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject notLobby;
    public GameObject lobby;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        notLobby.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MultiplayerStartGame()
    {
        notLobby.SetActive(true);
        lobby.SetActive(false);
        Time.timeScale = 1;
    }
}

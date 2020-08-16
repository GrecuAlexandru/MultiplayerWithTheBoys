using UnityEngine;
using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform spawnPoint0;
    [SerializeField]
    private Transform spawnPoint1;
    [SerializeField]
    private Transform spawnPoint2;
    [SerializeField]
    private Transform spawnPoint3;

    int numberPlayers;
    bool StartGame = false;

    void Start()
    {
       
        StartGame = true;
    }
    void Update()
    {
        Debug.Log(PhotonNetwork.GetPing());
        if (StartGame)
        {
            CheckPlayers();
            if (numberPlayers == 1)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PhotonPlayer"), spawnPoint0.position, spawnPoint0.rotation, 0);
                numberPlayers = 2;
                StartGame = false;
                //ConnectButton.Connect = false;
            }
            else if (numberPlayers == 2)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), spawnPoint1.position, spawnPoint1.rotation, 0);
                numberPlayers = 3;
                //ConnectButton.Connect = false;
                StartGame = false;
            }
            else if (numberPlayers == 3)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), spawnPoint2.position, spawnPoint2.rotation, 0);
                numberPlayers = 4;
                //ConnectButton.Connect = false;
                StartGame = false;
            }
            else if (numberPlayers == 4)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), spawnPoint3.position, spawnPoint3.rotation, 0);
                numberPlayers = 1;
                //ConnectButton.Connect = false;
                StartGame = false;
            }
        }
    }

    void CheckPlayers()
    {
        numberPlayers = PhotonNetwork.CountOfPlayers;
        //if the number of player is heigher than the number of spawnpoint in the game (in this case 4),
        //spawn the players in round order
        for (int i = 0; i <= numberPlayers; i++)
        {
            if (numberPlayers > 4)
            {
                numberPlayers -= 4;
            }

        }
    }
}
 
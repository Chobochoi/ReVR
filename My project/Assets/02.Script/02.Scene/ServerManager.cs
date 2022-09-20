using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public Button connect;
    public TMP_Text region;
    public TMP_Text lobby;

    public void Awake()
    {
        DontDestroyOnLoad(this);        
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Update()
    {
        region.text = PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion;

        switch (Data.count)
        {
            case 0:
                lobby.text = "A Company";
                break;
            case 1:
                lobby.text = "B Company";
                break;
            case 2:
                lobby.text = "C Company";
                break;
        }
    }
    public override void OnConnectedToMaster()
    {
        switch (Data.count)
        {
            case 0: PhotonNetwork.JoinLobby(new TypedLobby("A Company", LobbyType.Default));
                break;
            case 1: PhotonNetwork.JoinLobby(new TypedLobby("B Company", LobbyType.Default));
                break;
            case 2: PhotonNetwork.JoinLobby(new TypedLobby("C Company", LobbyType.Default));
                break;
        }
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("01.Scenes/03.Show");
    }
}

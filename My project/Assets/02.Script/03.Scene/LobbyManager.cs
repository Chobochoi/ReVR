using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField RoomName, RoomPerson;
    public Button RoomCreate, RoomJoin;

    public GameObject RoomPrefab;
    public Transform RoomContent;

    Dictionary<string, RoomInfo> RoomCatalog = new Dictionary<string, RoomInfo>();    

    private void Update()
    {
        //if (RoomName.text.Length > 0)
        //    RoomJoin.interactable = true;
        //else
        //    RoomJoin.interactable = false;

        //if (RoomName.text.Length > 0 && RoomPerson.text.Length > 0)
        //    RoomCreate.interactable = true;
        //else
        //    RoomCreate.interactable = false;        
        RoomJoin.interactable = true;
        RoomCreate.interactable = true; 
    }

    // 상세보기 페이지로 생각하기
    // Show를 3번방으로 설정하기
    public void OnClickCreateRoom()
    {
        RoomOptions Room = new RoomOptions();
        Room.MaxPlayers = 8;
        Room.IsOpen = true;
        Room.IsVisible = true;
        PhotonNetwork.CreateRoom(RoomName.text, Room);
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomName.text);        
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
    }

    public void AllDeleteRoom()
    {
        foreach (Transform trans in RoomContent)
        {
            Destroy(trans.gameObject);
        }
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel("01.Scenes/04.Deatail1");
        switch (Data.count)
        {
            case 0:
                PhotonNetwork.JoinRoom("01.Scenes/04.Detail1");
                break;
            case 1:
                PhotonNetwork.JoinRoom("01.Scenes/04.Detail2");
                break;
            case 2:
                PhotonNetwork.JoinRoom("01.Scenes/04.Detail3");
                break;
            case 3:
                PhotonNetwork.JoinRoom("01.Scenes/04.Detail4");
                break;
        }
    }

    // 추가했음 테스트. 22/09/13
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("01.Scenes/02.Server");
        DontDestroyOnLoad(this);
    }

    public void CreateRoomObject()
    {
        foreach (RoomInfo info in RoomCatalog.Values)
        {
            GameObject room = Instantiate(RoomPrefab);

            room.transform.SetParent(RoomContent);

            room.GetComponent<Information>().SetInfo(info.Name, info.PlayerCount, info.MaxPlayers);
        }
    }

    void UpdateRoom(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (RoomCatalog.ContainsKey(roomList[i].Name))
            {
                if (roomList[i].RemovedFromList)
                {
                    RoomCatalog.Remove(roomList[i].Name);
                    continue;
                }
            }
            RoomCatalog[roomList[i].Name] = roomList[i];
        }
    }
}

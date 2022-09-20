using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MyManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 30;
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhontonControl : MonoBehaviourPunCallbacks
{
    public Camera cam;
    
    void Start()
    {
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            cam.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine) return;
    }
}

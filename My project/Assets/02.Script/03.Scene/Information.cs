using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;


public class Information : MonoBehaviour
{
    public TMP_Text RoomData;

    public void SetInfo(string Name, int Current, int Max)
    {
        RoomData.text = Name + "(" + Current + "/" + Max + ")";
    }
}

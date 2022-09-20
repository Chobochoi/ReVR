using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffManager : MonoBehaviour
{
    [SerializeField] Button Onbtn;
    [SerializeField] Canvas can1;
    [SerializeField] Canvas can2;
    InputManager inputManager;       

    public void SetButton()
    {
        can1.gameObject.SetActive(true);
        can2.gameObject.SetActive(true);
    }
}
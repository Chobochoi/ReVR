using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.InputSystem;

public class DetailManager : MonoBehaviourPunCallbacks
{  
    public float rayDistance = 30.0f;
    public RaycastHit[] hitData;
   

    public void Update()
    {
        DetailLoader();
    }       

    public void DetailLoader()
    {
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
          
        hitData = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

        //if (Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity, LayerMask.GetMask("UI")));
        foreach (var item in hitData)
        {
            switch (item.transform.gameObject.name)
            {
                case "Button1":
                    Debug.Log("in");
                    SceneManager.LoadScene("01.Scenes/05.Detail1");
                    break;
                case "Button2":
                    SceneManager.LoadScene("01.Scenes/05.Detail2");
                    break;
                case "Button3":
                    SceneManager.LoadScene("01.Scenes/05.Detail3");
                    break;
                case "Button4":
                    SceneManager.LoadScene("01.Scenes/05.Detail4");
                    break;

                    DontDestroyOnLoad(gameObject);
            }
        }       
           
    }

    

    
}

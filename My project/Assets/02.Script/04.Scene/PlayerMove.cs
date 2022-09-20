using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    public float moveSpeed = 3.0f;
    public float rotSpeed = 200.0f;
    public GameObject cameraRig;
    public Transform myCharactor;
    //public Animator anim;
    public Text nameText;

    Vector3 setPos;
    Quaternion setRot;
    float dir_speed = 0;
    
    void Start()
    {
        cameraRig.SetActive(photonView.IsMine);            
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        if (photonView.IsMine)
        {
            Vector2 stickPos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
            Vector3 dir = new Vector3(stickPos.x, 0, stickPos.y);
            dir.Normalize();

            dir = cameraRig.transform.TransformDirection(dir);
            transform.position += dir * moveSpeed * Time.deltaTime;

            float magnitude = dir.magnitude;

            if (magnitude > 0)
            {
                myCharactor.rotation = Quaternion.LookRotation(dir);
            }

            //anim.SetFloat("Speed", magnitude);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, setPos, Time.deltaTime * 20.0f);
            myCharactor.rotation = Quaternion.Lerp(myCharactor.rotation, setRot, Time.deltaTime * 20.0f);

            //anim.SetFloat("Speed", dir_speed);
        }
    }

    void Rotate()
    {
        if (photonView.IsMine)
        {
            float rotH = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;

            cameraRig.transform.eulerAngles += new Vector3(0, rotH, 0) * rotSpeed * Time.deltaTime;
        }        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(myCharactor.rotation);
            //stream.SendNext(anim.GetFloat("Speed"));
        }
        else if (stream.IsReading)
        {
            setPos = (Vector3)stream.ReceiveNext();
            setRot = (Quaternion)stream.ReceiveNext();
            dir_speed = (float)stream.ReceiveNext();

        }
    }
}

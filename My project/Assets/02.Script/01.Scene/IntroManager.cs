using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;


public class IntroManager : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField username;
    //public TMP_InputField region;

    public void LoginSuccess(LoginResult result)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        // ���� ������ ������ �� �ְ� 1.0v
        PhotonNetwork.GameVersion = "1.0";

        // �г��� ����
        PhotonNetwork.NickName = username.text;

        // ���� ����
        //PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.text;

        // ���� ����
        PhotonNetwork.LoadLevel("01.Scenes/02.Server");
    }

    public void LoginFailure(PlayFabError error)
    {
        Debug.Log("l.f");
    }

    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("success");
    }

    public void SignUpFailure(PlayFabError error)
    {
        Debug.Log("fail");
    }

    public void SignUp()
    {
        // ������ ���� ��� ��Ű�� ����
        var request = new RegisterPlayFabUserRequest()
        {
            Email = email.text,
            Password = password.text,
            Username = username.text
        };

        // request : ȸ������ ����
        PlayFabClientAPI.RegisterPlayFabUser
        (request, SignUpSuccess, SignUpFailure);
    }

    public void Login()
    {
        // �α��� ���� ����
        var request = new LoginWithEmailAddressRequest()
        {
            Email = email.text,
            Password = password.text
        };


        PlayFabClientAPI.LoginWithEmailAddress
        (request, LoginSuccess, LoginFailure);
    }
}

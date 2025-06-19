using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Chat : MonoBehaviour, IPunObservable
{
    public TMP_InputField inputField;
    public GameObject message;
    public GameObject Content;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
    public void SendMessageBTN()
    {
        gameObject.GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, (PhotonNetwork.NickName + ": " + inputField.text));

        inputField.text = "";
    }

    [PunRPC]
    public void GetMessage(string ReceiveMessage)
    {
        GameObject M = Instantiate(message, Vector3.zero, Quaternion.identity, Content.transform);
        M.GetComponent<Message>().MyMessage.text = ReceiveMessage;
    }
}

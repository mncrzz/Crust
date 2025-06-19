using Photon.Pun;
using UnityEngine;
using TMPro;
public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField input_create;
    public TMP_InputField input_join;
    public TMP_InputField tMP_InputField;
    public string roomNameToJoin;
    public static LobbyManager Instance;
    public GameObject loading;
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        tMP_InputField.text = PlayerPrefs.GetString("name");
        PhotonNetwork.NickName = tMP_InputField.text;
        loading.SetActive(false);
    }
    public void CreateRoom()
    {
        loading.SetActive(true);
        PhotonNetwork.CreateRoom(input_create.text);
    }
    public void JoinRoom()
    {
        loading.SetActive(true);
        PhotonNetwork.JoinRoom(input_join.text);
    }
    public void JoinRoomViaList(string _name)
    {
        loading.SetActive(true);
        PhotonNetwork.JoinRoom(_name);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public void SaveName()
    {
        PlayerPrefs.SetString("name", tMP_InputField.text);
        PhotonNetwork.NickName = tMP_InputField.text;
    }
    
}

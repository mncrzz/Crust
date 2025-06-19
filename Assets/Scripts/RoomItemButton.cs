using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomItemButton : MonoBehaviour
{
    private string RoomName;
    private void Start()
    {
        RoomName = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
    }
    public void OnButtonPressed()
    {
        LobbyManager.Instance.JoinRoomViaList(RoomName);
    }
}

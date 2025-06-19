using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Vector3 positionSpawn = new Vector3(15, 2, 0);
        PhotonNetwork.Instantiate(player.name, gameObject.transform.position, Quaternion.identity);
    }
}

using UnityEngine;
using Photon.Pun;
public class InfoPlayer : MonoBehaviour, IPunObservable
{
    public float HP = 1f;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(HP);
        }
        else
        {
            HP = (float)stream.ReceiveNext();
        }
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}

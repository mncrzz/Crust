using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;

public class GunShoot : MonoBehaviourPunCallbacks
{
    [Header("Gun system")]
    public Transform _camera;
    public ParticleSystem ps;
    public GameObject hole;
    [Header("R_arm")]
    public GameObject gun;
    public GameObject build_plan;
    public GameObject konfeta;

    public void ShootBTN()
    {
        if (FastInventory.Instance.activeItem.name == "Пистолет")
        {
            if (photonView.IsMine)
            {
                photonView.RPC("RPC_shoot", RpcTarget.All);
                ps.Play();

                Ray ray = new Ray(_camera.position, _camera.forward);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                {
                    Instantiate(hole);
                    hole.transform.position = hit.point;
                }
            }
        }
        if (FastInventory.Instance.activeItem.name == "Револьвер")
        {
            if (photonView.IsMine)
            {
                photonView.RPC("RPC_shoot", RpcTarget.All);
                ps.Play();

                Ray ray = new Ray(_camera.position, _camera.forward);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                {
                    Instantiate(hole);
                    hole.transform.position = hit.point;
                }
            }
        }
        if (FastInventory.Instance.activeItem.name == "Топор")
        {
            Ray raywood = new Ray(_camera.position, _camera.forward);

            if (Physics.Raycast(raywood, out RaycastHit hitwood, 1f))
            {
                if(hitwood.transform.tag == "Tree")
                {
                    FastInventory.Instance.wood += 10;
                    SoundManager.Instance.isAxe = true;
                    Debug.Log(FastInventory.Instance.wood);
                }
            }
            else
            {
                SoundManager.Instance.PlaySoundNull();
            }
        }
        if(FastInventory.Instance.activeItem.name == "План" && BuildManager.Instance.created != null)
        {
            if(FastInventory.Instance.wood >= 20 || FastInventory.Instance.wood == 20)
            {
                FastInventory.Instance.wood += 20;
                if(FastInventory.Instance.wood <= 0)
                {
                    FastInventory.Instance.wood = 0;
                }
                BuildManager.Instance.created = null;
                return;
            }
        }
    }

    [PunRPC]
    void RPC_shoot()
    {
        Ray ray = new Ray(_camera.position, _camera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            var enemyHP = hit.collider.GetComponent<InfoPlayer>();
            if (enemyHP)
            {
                enemyHP.TakeDamage(0.2f);
            }
        }
    }
}

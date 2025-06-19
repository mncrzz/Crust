using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class BuildManager : MonoBehaviourPunCallbacks
{
    public GameObject prefab;
    [HideInInspector]
    public GameObject created;
    public Vector3 rot;
    Quaternion trot;
    public static BuildManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (BuildChecker.Instance.canBuild == true)
        {
            if (created != null)
            {
                trot = Quaternion.Lerp(created.transform.rotation, Quaternion.Euler(rot), 0.2f);
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    destroyBlock();
                }
            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position + (transform.forward * 5f), Vector3.down, out hit))
            {
                var pos = new Vector3(Mathf.Round(hit.point.x / 3f) * 3f,
                                     hit.point.y + 1.5f,
                                     Mathf.Round(hit.point.z / 3f) * 3f);

                if (prefab != null)
                {
                    if (created == null)
                    {
                        created = PhotonNetwork.Instantiate(prefab.name, pos, Quaternion.Euler(rot));
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            if (change_guns.Instance.build_plan_viewmodel.activeSelf == true)
                            {
                                rotateBlock();
                            }
                        }
                        created.transform.rotation = trot;
                        created.transform.position = Vector3.Lerp(created.transform.position, pos, 10f * Time.deltaTime);
                    }
                }
            }
        }
    }
    public void rotateBlock()
    {
        rot += new Vector3(0, 90f, 0);
    }
    public void destroyBlock()
    {
        Destroy(created.gameObject);
        prefab = null;
    }

}

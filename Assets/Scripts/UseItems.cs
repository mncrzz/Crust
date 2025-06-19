using UnityEngine;
using EPOOutline;

public class UseItems : MonoBehaviour
{
    public Transform _camera;
    void Update()
    {
        Ray ray = new Ray(_camera.position, _camera.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, 1.5f))
        {
            if(hit.transform.name == "печка") hit.transform.GetComponent<Outlinable>().enabled = true;
        }
    }
}
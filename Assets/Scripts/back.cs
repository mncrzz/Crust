using UnityEngine;

public class Back : MonoBehaviour
{
    public Transform point;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.transform.position = point.transform.position;
    }
}
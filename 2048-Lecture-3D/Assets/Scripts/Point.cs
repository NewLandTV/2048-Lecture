using UnityEngine;

public class Point : MonoBehaviour
{
    public bool Collision { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        Collision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Collision = false;
    }
}

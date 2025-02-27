using UnityEngine;

public class SetcenterOfMass : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform position;
    private void Start()
    {
        rb.centerOfMass = position.localPosition;
    }
}

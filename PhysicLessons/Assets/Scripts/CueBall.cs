using UnityEngine;

public class CueBall : MonoBehaviour
{
    public float force = 500f; 
    void Start()
    {
       Rigidbody rb = GetComponent<Rigidbody>();
       rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
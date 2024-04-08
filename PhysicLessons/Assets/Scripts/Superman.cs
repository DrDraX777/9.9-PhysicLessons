using UnityEngine;

public class Superman : MonoBehaviour
{
    public float punchForce = 1000f; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BadGuy"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = collision.transform.position - transform.position;
                rb.AddForce(forceDirection.normalized * punchForce);
            }
        }
    }
}

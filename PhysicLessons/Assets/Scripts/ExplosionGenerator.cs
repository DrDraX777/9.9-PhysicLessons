using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    public float explosionForce = 1000f; 
    public float radius = 5f; 
    public float explosionInterval = 3f; 
    private float nextExplosionTime = 0f; 

    private void Update()
    {
        if (Time.time >= nextExplosionTime)
        {
            GenerateExplosion();
            nextExplosionTime = Time.time + explosionInterval; 
        }
    }
    private void GenerateExplosion()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in blocks)
        {
            if (Vector3.Distance(transform.position, rb.transform.position) < radius)
            {
                Vector3 direction = rb.transform.position - transform.position;
                rb.AddForce(direction.normalized * explosionForce * (radius - Vector3.Distance(transform.position, rb.transform.position)), ForceMode.Impulse);
            }
        }
    }
}
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    public float explosionForce = 1000f; // Сила взрыва
    public float radius = 5f; // Радиус взрыва
    public float explosionInterval = 3f; // Интервал между взрывами в секундах

    private float nextExplosionTime = 0f; // Время следующего взрыва

    private void Update()
    {
        // Проверяем, пришло ли время для следующего взрыва
        if (Time.time >= nextExplosionTime)
        {
            GenerateExplosion();
            nextExplosionTime = Time.time + explosionInterval; // Устанавливаем время следующего взрыва
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
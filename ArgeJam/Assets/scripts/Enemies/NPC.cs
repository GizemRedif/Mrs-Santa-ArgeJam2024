using UnityEngine;

public class NPC : MonoBehaviour
{
    public Vector2[] patrolPoints; // Düþmanýn gezeceði noktalar
    public float speed = 2f; // Hareket hýzý
    private int currentPointIndex = 0; // Þu anda hedeflenen noktanýn indeksi
    public Vector2 direction;
    void Start()
    {
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return; // Nokta yoksa çýk
        // Hedef noktaya doðru hareket et
        Vector2 targetPoint = patrolPoints[currentPointIndex];
        Vector3 targetPosition = new Vector3(targetPoint.x, targetPoint.y, transform.position.z);

        // Hedef pozisyona doðru hareket et
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        SetDirection(targetPoint);
        // Hedef noktaya ulaþýldýysa bir sonraki noktaya geç
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
    private void SetDirection(Vector2 targetDirection)
    {
        if (targetDirection.x < transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

        }
    }
}

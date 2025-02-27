using UnityEngine;

public class NPC : MonoBehaviour
{
    public Vector2[] patrolPoints; // D��man�n gezece�i noktalar
    public float speed = 2f; // Hareket h�z�
    private int currentPointIndex = 0; // �u anda hedeflenen noktan�n indeksi
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
        if (patrolPoints.Length == 0) return; // Nokta yoksa ��k
        // Hedef noktaya do�ru hareket et
        Vector2 targetPoint = patrolPoints[currentPointIndex];
        Vector3 targetPosition = new Vector3(targetPoint.x, targetPoint.y, transform.position.z);

        // Hedef pozisyona do�ru hareket et
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        SetDirection(targetPoint);
        // Hedef noktaya ula��ld�ysa bir sonraki noktaya ge�
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

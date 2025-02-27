using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Vector2[] patrolPoints; // D��man�n gezece�i noktalar
    public float speed = 4f; // Hareket h�z�
    private int currentPointIndex = 0; // �u anda hedeflenen noktan�n indeksi
    public float viewDistance; // G�r�� mesafesi
    public float viewRange; // G�r�� geni�li�i
    public LayerMask detectionLayer; // Tespit edilecek layer
    private Vector2 direction; // Y�n vekt�r�
    public Transform view; // G�r�� alan�
    public float detectedTime = 1; // Oyuncu alg�land�ktan sonra ge�en s�re
    public float detectedTimer = 0; // Oyuncu alg�land�ktan sonra ge�en s�re
    void Start()
    {
    }

    void Update()
    {
        Patrol();
        DetectPlayer();
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // G�r�� alan�n� �iz
        Vector3 gizmoPosition = transform.position + (Vector3)(direction * viewDistance / 2);
        Gizmos.DrawWireCube(gizmoPosition, new Vector3(
            Mathf.Abs(direction.x) > 0 ? viewDistance : viewRange, // X ekseni geni�li�i
            Mathf.Abs(direction.y) > 0 ? viewDistance : viewRange, // Y ekseni y�ksekli�i
            0
        ));
    }

    private bool DetectPlayer()
    {
        // BoxCast ba�lang�� pozisyonu
        Vector3 boxOrigin = transform.position + (Vector3)(direction * viewDistance / 2);

        // BoxCast i�lemi
        RaycastHit2D hit = Physics2D.BoxCast(
            boxOrigin,
            new Vector2(
                Mathf.Abs(direction.x) > 0 ? viewDistance : viewRange, // X ekseni geni�li�i
                Mathf.Abs(direction.y) > 0 ? viewDistance : viewRange  // Y ekseni y�ksekli�i
            ),
            0,
            direction,
            0,
            detectionLayer
        );

        // Oyuncuyu alg�la
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Debug.DrawLine(transform.position, hit.transform.position, Color.green);
            if (detectedTime < detectedTimer)
            {
                hit.collider.GetComponent<deneme>().enabled = false;
                hit.collider.GetComponent<Animator>().enabled = false;
                hit.collider.GetComponent<Rigidbody2D>().simulated = false;
                SceneManager.LoadScene("ArrestedEnd");

                return true;

            }
            detectedTimer += Time.deltaTime;
            return true;
        }
        detectedTimer = 0;
        return false;
    }

    private void SetDirection(Vector2 targetPoint)
    {
        // Yukar�, a�a��, sa� veya sola bakaca��n� belirle
        if (Mathf.Abs(targetPoint.y - transform.position.y) > Mathf.Abs(targetPoint.x - transform.position.x))
        {
            // Yukar� veya a�a�� bak
            if (targetPoint.y > transform.position.y)
            {
                view.transform.position = new Vector3(transform.position.x, transform.position.y + viewDistance / 2, transform.position.z);
                view.transform.rotation = Quaternion.Euler(0, 0, 90);
                direction = Vector2.up; // Yukar�
            }
            else
            {
                view.transform.position = new Vector3(transform.position.x, transform.position.y - viewDistance / 2, transform.position.z);
                view.transform.rotation = Quaternion.Euler(0, 0, -90);
                direction = Vector2.down; // A�a��
            }
        }
        else
        {
            // Sa�a veya sola bak
            if (targetPoint.x > transform.position.x)
            {
                direction = Vector2.right; // Sa�a

                if (transform.localScale.x > 0) // Sprite y�n�n� d�zelt (sa� tarafa d�n)
                {
                   
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                view.transform.position = new Vector3(transform.position.x + viewDistance / 2, transform.position.y, transform.position.z);
                view.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                direction = Vector2.left; // Sola

                if (transform.localScale.x < 0) // Sprite y�n�n� d�zelt (sol tarafa d�n)
                {
                    
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                view.transform.position = new Vector3(transform.position.x - viewDistance / 2, transform.position.y, transform.position.z);
                view.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
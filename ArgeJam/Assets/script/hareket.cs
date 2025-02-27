using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket h�z�
    public Rigidbody2D rb; // Rigidbody2D bile�eni
    public Animator animator; // Animator bile�eni (animasyonlar i�in)

    private Vector2 movement; // Hareket y�n�n� tutar

    void Update()
    {
        // Klavye giri�lerini al
        movement.x = Input.GetAxisRaw("Horizontal"); // Sa�-sol hareketi
        movement.y = Input.GetAxisRaw("Vertical");   // Yukar�-a�a�� hareketi

        // Animasyon parametrelerini ayarla (animat�r kullan�yorsan�z)
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); // Hareket olup olmad���n� kontrol
        }
    }

    void FixedUpdate()
    {
        // Rigidbody kullanarak karakteri hareket ettir
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

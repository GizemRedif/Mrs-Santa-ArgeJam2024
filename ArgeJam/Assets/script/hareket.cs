using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket hýzý
    public Rigidbody2D rb; // Rigidbody2D bileþeni
    public Animator animator; // Animator bileþeni (animasyonlar için)

    private Vector2 movement; // Hareket yönünü tutar

    void Update()
    {
        // Klavye giriþlerini al
        movement.x = Input.GetAxisRaw("Horizontal"); // Sað-sol hareketi
        movement.y = Input.GetAxisRaw("Vertical");   // Yukarý-aþaðý hareketi

        // Animasyon parametrelerini ayarla (animatör kullanýyorsanýz)
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); // Hareket olup olmadýðýný kontrol
        }
    }

    void FixedUpdate()
    {
        // Rigidbody kullanarak karakteri hareket ettir
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

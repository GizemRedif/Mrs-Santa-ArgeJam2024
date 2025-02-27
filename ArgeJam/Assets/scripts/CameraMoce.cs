using UnityEngine;

public class CameraMoce : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter
    public Vector3 offset; // Kameranın karaktere göre konumu
    public float smoothSpeed = 0.125f; // Kameranın hareket yumuşaklığı

    void LateUpdate()
    {
        // İstenilen kamera pozisyonunu hesapla
        Vector3 desiredPosition = target.position + offset;

        // Kamerayı yumuşakça hareket ettir
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
    }
}

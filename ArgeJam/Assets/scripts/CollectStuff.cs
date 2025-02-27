using System.Collections.Generic;
using UnityEngine;

public class CollectStuff : MonoBehaviour
{
    public float interactionDistance = 2f; // Karakterin eşya ile etkileşime geçebileceği mesafe
    public KeyCode interactionKey = KeyCode.F; // Etkileşim tuşu

    private string[] collectedStuff = new string[20]; // Toplanan eşyaların isimleri için bir dizi
    private int collectedIndex = 0; // Dizideki mevcut index

    void Update()
    {
        CheckForStuff();
    }

    private void CheckForStuff()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionDistance);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Stuff"))
            {
                if (Input.GetKeyDown(interactionKey))
                {
                    Collect(hitCollider.gameObject);
                }
            }
        }
    }

    private void Collect(GameObject stuff)
    {
        // Eşyanın ismini diziye ekle
        if (collectedIndex < collectedStuff.Length)
        {
            collectedStuff[collectedIndex] = stuff.name;
            collectedIndex++;
        }
        else
        {
            Debug.LogError("CollectedStuff dizisi dolu! Daha fazla eşya toplanamaz.");
        }

        // Eşyayı görünmez yap
        Renderer stuffRenderer = stuff.GetComponent<Renderer>();
        if (stuffRenderer != null)
        {
            stuffRenderer.enabled = false;
        }

        // Collider'ını devre dışı bırak
        Collider stuffCollider = stuff.GetComponent<Collider>();
        if (stuffCollider != null)
        {
            stuffCollider.enabled = false;
        }

        Debug.Log(stuff.name + " toplandı!");
    }

    // Toplanan eşyaları görmek için bir yöntem
    public void PrintCollectedStuff()
    {
        Debug.Log("Toplanan Eşyalar:");
        for (int i = 0; i < collectedIndex; i++)
        {
            Debug.Log(collectedStuff[i]);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Etkileşim mesafesini görselleştirmek için bir küre çiz
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class StuffInteraction : MonoBehaviour
{
    public List<string> collectedItems = new List<string>(); // Görünmez olan eşyaların isimlerini tutacak liste
    public float interactionRange = 2f; // Etkileşim mesafesi

    void Update()
    {
        // "F" tuşuna basıldığında işlemi kontrol et
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckForStuff();
        }
    }
    public int GetLength()
    {
        return collectedItems.Count;
    }
    void CheckForStuff()
    {
        // Sahnedeki tüm "Stuff" tag'ine sahip objeleri bul
        GameObject[] stuffs = GameObject.FindGameObjectsWithTag("Stuff");

        foreach (GameObject stuff in stuffs)
        {
            float distance = Vector3.Distance(transform.position, stuff.transform.position);

            // Eğer eşya belirtilen mesafede ise
            if (distance <= interactionRange)
            {
                // Eşyayı görünmez yap
                stuff.SetActive(false);

                // İsmini listeye ekle
                collectedItems.Add(stuff.name);

                Debug.Log(stuff.name + " collected!");
                PlayerPrefs.SetInt(stuff.name,1);
                // İlk bulduğumuz eşyayı işlediğimiz için döngüyü bitiriyoruz
                break;
            }
        }
    }
}

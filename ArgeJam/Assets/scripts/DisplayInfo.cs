using TMPro;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    public TextMeshProUGUI uiText; // TextMeshPro nesnesini buraya ba�lay�n
    public GameObject player; // Oyuncu nesnesini buraya ba�lay�n

    void Start()
    {
        UpdateText(); // �lk metin g�ncellemesi
    }

    void Update()
    {
        
        UpdateText();
     
    }

    void UpdateText()
    {
        deneme character = player.GetComponent<deneme>();
        uiText.text = "TIME LEFT: " + (int)character.healthTimer; // Sa�l�k bilgisini yazd�r
    }
}

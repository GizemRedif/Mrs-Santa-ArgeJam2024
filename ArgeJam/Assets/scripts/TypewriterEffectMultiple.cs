using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffectMultiple : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // TextMeshPro bileşeni
    public float revealSpeed = 0.5f; // Harflerin çıkış hızı (saniye)

    private string fullText = " "; // Tam metni tutar

    void Start()
    {

        
    }
    void Awake()
    {
        // TextMeshPro bileşenini otomatik bul (Eğer atanmadıysa)
         if (textMeshPro == null)
             textMeshPro = GetComponent<TextMeshProUGUI>();

        if (fullText != null){
            fullText = " " + textMeshPro.text ;
        textMeshPro.text = " ";
        }

        // Başlangıçta yazıyı sakla
        
        
    }

    public void StartReveal()
    {
        StopAllCoroutines();
        StartCoroutine(RevealText());
    }

    private IEnumerator RevealText()
    {
        textMeshPro.text = ""; // Metni sıfırla
        for (int i = 0; i <= fullText.Length; i++)
        {
            textMeshPro.text = fullText.Substring(0, i); // Harf harf ekle
            yield return new WaitForSeconds(revealSpeed); // Bekle
        }
    }
}

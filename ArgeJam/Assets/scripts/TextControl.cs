using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextControl : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject devam;

    private int listIndex = 0;
    private List<GameObject> textList;

    void Start()
    {
        textList = new List<GameObject> { text1, text2, text3, text4 };

        // İlk metni aktif hale getirin ve animasyonu başlatın
        if (textList.Count > 0)
        {
            StartTextReveal(textList[0]);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mevcut metni pasif hale getir
            textList[listIndex].SetActive(false);

            // Sonraki metni aktif hale getir
            if (listIndex + 1 < textList.Count)
            {
                listIndex++;
                StartTextReveal(textList[listIndex]);
            }
            else
            {
                // Tüm metinler gösterildiyse, sahneyi değiştir
                SceneManager.LoadScene("sahne1");
            }
        }
    }

    private void StartTextReveal(GameObject textObject)
    {
        textObject.SetActive(true);
        TypewriterEffectMultiple textReveal = textObject.GetComponent<TypewriterEffectMultiple>();
        if (textReveal != null)
        {
            textReveal.StartReveal();
        }
    }
}

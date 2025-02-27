using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaperToggle : MonoBehaviour
{

    public GameObject interactionScriptObject; // StuffInteraction scriptinin bağlı olduğu obje
    private StuffInteraction stuffInteraction;

    public List<TMP_Text> itemTexts; // Paneldeki yazıları temsil eden TextMeshPro objeleri


    public GameObject paperPanel;
    private bool isPaperVisible = false;

    [System.Obsolete]
    void Start()
    {
        stuffInteraction = FindObjectOfType<StuffInteraction>();

        paperPanel.SetActive(false);

        // StuffInteraction scriptine eriş
        if (interactionScriptObject != null)
        {
            stuffInteraction = interactionScriptObject.GetComponent<StuffInteraction>();
        }

        if (stuffInteraction == null)
        {
            Debug.LogError("StuffInteraction scripti bulunamadı!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isPaperVisible = !isPaperVisible;
            paperPanel.SetActive(isPaperVisible);
        }
        if (stuffInteraction != null)
        {
            UpdatePanel();
        }
    }

     void UpdatePanel()
    {
        // Tüm topladığımız stuff'ları kontrol et
        foreach (string collectedItem in stuffInteraction.collectedItems)
        {
            foreach (TMP_Text textItem in itemTexts)
            {
                // Eğer eşyanın ismi yazıya uyuyorsa üzerini çiz
                if (textItem.text == collectedItem && !textItem.text.Contains("<s>"))
                {
                    textItem.text = "<s>" + textItem.text + "</s>"; // Üzerini çizer
                    Debug.Log(collectedItem + " panelde çizildi!");
                }
                if(PlayerPrefs.GetInt(textItem.text) == 1){
                    
                    textItem.text = "<s>" + textItem.text + "</s>"; // Üzerini çizer
                    Debug.Log(collectedItem + " panelde çizildi!");
                }
            }
        }
    }
}

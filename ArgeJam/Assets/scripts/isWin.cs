
using UnityEngine;
using UnityEngine.SceneManagement;

public class isWin : MonoBehaviour
{
 
        private StuffInteraction stuffInteraction;
        private int giftCount;


    [System.Obsolete]
    void Start()
    {
                stuffInteraction = FindObjectOfType<StuffInteraction>();


    }

    void Update()
    {
        if(stuffInteraction.GetLength() == 6 && PlayerPrefs.GetInt("gift")==4 && PlayerPrefs.GetInt("Timer") > 0){
            SceneManager.LoadScene("HappyEnd");
        }
        
    }
}

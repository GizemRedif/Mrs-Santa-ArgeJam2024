using UnityEngine;

public class DeliverGift : MonoBehaviour
{
    public GameObject gift;
    public GameObject arrow;
        void Start()
    {
        arrow.SetActive(true);
        gift.SetActive(false);
    }

    
    void OnTriggerStay2D(Collider2D other)
    {
       if(other.CompareTag("Player")){
            if(Input.GetMouseButton(1)){
                gift.SetActive(true);
                PlayerPrefs.SetInt("gift",PlayerPrefs.GetInt("gift")-1);
                arrow.SetActive(false);
            }
       } 
    }
    
        
    
    void Update()
    {
        
    }
}

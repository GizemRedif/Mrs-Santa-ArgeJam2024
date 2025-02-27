using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject[] exitlocation; 
    void Start()
    {
        PlayerPrefs.SetInt("house",0);
        if(PlayerPrefs.GetInt("house") == 1){Player.transform.position = exitlocation[0].transform.position;}
        else if (PlayerPrefs.GetInt("house") == 2){Player.transform.position = exitlocation[1].transform.position;}
        else if (PlayerPrefs.GetInt("house") == 3){Player.transform.position = exitlocation[2].transform.position;}
        else if (PlayerPrefs.GetInt("house") == 4){Player.transform.position = exitlocation[3].transform.position;}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

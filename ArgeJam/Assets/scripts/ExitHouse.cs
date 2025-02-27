using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitHouse : MonoBehaviour
{
    string currentSceneName;
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if(Input.GetKey(KeyCode.E)){
                if(currentSceneName.Equals("Home1")){PlayerPrefs.SetInt("house",1);}
                else if(currentSceneName.Equals("Home2")){PlayerPrefs.SetInt("house",2);}
                else if(currentSceneName.Equals("Home3")){PlayerPrefs.SetInt("house",3);}
                else if(currentSceneName.Equals("Home4")){PlayerPrefs.SetInt("house",4);}
                SceneManager.LoadScene("Sahne1");
                
            }
        }
    }
}

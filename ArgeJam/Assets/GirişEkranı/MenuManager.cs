using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
     PlayerPrefs.SetInt("Avokado",0);
     PlayerPrefs.SetInt("Somon",0);
     PlayerPrefs.SetInt("Ejder Meyvesi",0);
     PlayerPrefs.SetInt("But",0);
     PlayerPrefs.SetInt("Domates",0);
     PlayerPrefs.SetInt("Ekmek",0);
     PlayerPrefs.SetFloat("Timer",300);
    }

    void Update() 
    {
        // Q tuşuna basıldığında "Baslangıç" sahnesine dön
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("StartScene");
        }
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Story"); //Hikaye ekranına gider
    }

    public void SettingsButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Settings");
    }

    public void DevelopersButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Developers"); //Hikaye ekranına gider
    }

    public void HowToPlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HowToPlay"); //Hikaye ekranına gider
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        Application.Quit();
    }


}

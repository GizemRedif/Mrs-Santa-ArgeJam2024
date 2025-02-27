using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartScene : MonoBehaviour
{
    void Update()
    {
        // Sol fare butonuna tıklanıp tıklanmadığını kontrol ediyoruz.
        if (Input.GetMouseButtonDown(0))
        {
            // Başlangıç sahnesine geçiş yapıyoruz. "StartScene" adını kendi sahnenize göre değiştirin.
            SceneManager.LoadScene("StartScene");
        }
    }
}

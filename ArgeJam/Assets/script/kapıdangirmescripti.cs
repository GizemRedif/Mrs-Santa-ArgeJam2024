using UnityEngine;
using UnityEngine.SceneManagement;

public class kapıdangirmescripti : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string sceneToLoad; // Geçiş yapılacak sahnenin adı
    public float detectionRadius = 3f; // Oyuncunun algılama yarıçapı
    private Transform player; // Oyuncu nesnesi

    void Start()
    {
        // Oyuncuyu sahnede bul
        player = GameObject.FindWithTag("Player").transform;
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadScene();
            }
        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadScene();
            }
        }
    }
    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadScene();
            }
        }
    }
    void Update()
    {
    }

    // Sahne yükleme fonksiyonu
    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}


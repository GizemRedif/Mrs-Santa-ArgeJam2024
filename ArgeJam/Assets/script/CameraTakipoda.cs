using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera[] cameraroom;
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.tag == "Kitchen")
            {
                for (int i = 0; i < cameraroom.Length; i++)
                {
                    cameraroom[i].gameObject.SetActive(false);
                }
                PlayerPrefs.SetInt("fireplace", 0);
                cameraroom[0].gameObject.SetActive(true);
            }
            else if (gameObject.tag == "Bedroom")
            {
                for (int i = 0; i < cameraroom.Length; i++)
                {
                    cameraroom[i].gameObject.SetActive(false);
                }
                PlayerPrefs.SetInt("fireplace", 0);
                cameraroom[1].gameObject.SetActive(true);
            }
            else if (gameObject.tag == "LivingRoom")
            {
                for (int i = 0; i < cameraroom.Length; i++)
                {
                    cameraroom[i].gameObject.SetActive(false);
                }
                PlayerPrefs.SetInt("fireplace", 1);
                cameraroom[2].gameObject.SetActive(true);
            }
            else if (gameObject.tag == "Entrance")
            {
                for (int i = 0; i < cameraroom.Length; i++)
                {
                    cameraroom[i].gameObject.SetActive(false);
                }
                PlayerPrefs.SetInt("fireplace", 0);
                cameraroom[3].gameObject.SetActive(true);
            }
        }
    }
    void Update()
    {

    }
}

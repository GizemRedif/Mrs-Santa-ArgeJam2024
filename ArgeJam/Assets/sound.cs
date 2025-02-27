using UnityEngine;

public class sound : MonoBehaviour
{
    [SerializeField] AudioSource AudioSrc ;
    void Start()
    {
        AudioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

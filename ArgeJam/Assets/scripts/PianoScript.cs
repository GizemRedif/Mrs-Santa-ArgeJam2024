using UnityEngine;

public class PianoScript : MonoBehaviour
{
    [SerializeField] AudioSource AudioSrc ;
    [SerializeField] AudioClip fireplace;
    int fireplacedetecter = 0;
    void Start()
    {
        fireplacedetecter = PlayerPrefs.GetInt("piano");
    }

    // Update is called once per frame
    void Update()
    {
        fireplacedetecter = PlayerPrefs.GetInt("piano");
        if (fireplacedetecter == 1 && !AudioSrc.isPlaying)
        {
            AudioSrc.Play();
        }
        else if (fireplacedetecter == 0 && AudioSrc.isPlaying)
        {
            AudioSrc.Stop();
        }
    }
}

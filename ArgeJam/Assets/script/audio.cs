using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class audio : MonoBehaviour
{

    public TextMeshProUGUI valumeamount;
    public Slider volumeSlider;
    void Start()
    {
        // Daha önce kaydedilen ses düzeyi varsa, onu yükle
        float savedVolume = PlayerPrefs.GetFloat("AudioVolume", 1f); // Varsayılan olarak 1 (maksimum ses)
        AudioListener.volume = savedVolume;
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
        }
        valumeamount.text = ((int)(savedVolume * 100)).ToString();
    }
    public void SetAudio (float value){
        AudioListener.volume = value;
        valumeamount.text = ((int)(value * 100)).ToString();

        // Ses düzeyini kaydet
        PlayerPrefs.SetFloat("AudioVolume", value);
        PlayerPrefs.Save(); // Değişiklikleri hemen diske yaz
    }
}

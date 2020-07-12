using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    const string VOLUME = "VOLUME";

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GetVolume();
    }
    
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME, volume);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME);
    }

    void Update()
    {
        SetVolume(volumeSlider.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        int numberMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numberMusicPlayer > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = FindObjectOfType<OptionsController>().GetVolume();
    }

    private void Update()
    {
        audioSource.volume = FindObjectOfType<OptionsController>().GetVolume();
    }
}

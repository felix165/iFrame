using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] sfxSound;
    public AudioSource sfxSource;

    public static float sfxVolume = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, x => x.name == name);

        if (s != null)
        {
            Debug.Log(name);
            sfxSource.clip = s.clip;
            sfxSource.Play();

        }
        else
        {
            Debug.Log("Sound Not Found");
        }
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        sfxSource.volume = sfxVolume;
    }
}

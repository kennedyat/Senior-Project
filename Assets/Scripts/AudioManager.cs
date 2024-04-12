using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;
    
    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start(){
        PlayMusic("Theme");
    }

    public void PlayMusic(string name){
        Sound s = Array.Find(music, x=> x.name == name);

        if (s == null){
            Debug.Log("Sound Not Found");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name){
        Sound s = Array.Find(sfx, x=> x.name == name);

        if (s == null || sfxSource.isPlaying){
            Debug.Log("SOund Not Found or Player");
        }
        else{
            sfxSource.PlayOneShot(s.clip);
        }
    }



}

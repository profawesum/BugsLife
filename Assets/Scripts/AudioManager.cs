using UnityEngine.Audio;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using System.Collections;


public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    public static AudioManager instance;

    private void Start()
    {
        float RandNum = UnityEngine.Random.Range(0, 100);
        if (RandNum <= 74)
        {
        //    Play("Wind");
        }
        else if (RandNum > 75)
        {
        //    Play("BusyAmbience");
        }

    }
    // Use this for initialization
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }        
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound i in Sounds)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.Clip;

            i.source.volume = i.vol;
            i.source.pitch = i.pit;
            i.source.loop = i.loop;
        }
    }

    public void Play(string name)
    {
        Sound i = Array.Find(Sounds, Sound => Sound.name == name);
        if (i == null)
        {
            Debug.LogWarning("Sound / SFX" + name + " Missing!");
            return;
        }
        i.source.Play();
    }

    public void Stop(string name)
    {
        Sound i = Array.Find(Sounds, Sound => Sound.name == name);
        Debug.Log("Tracking lost, stopping audio");
        if (i.source.isPlaying)
        {
            i.source.Stop();
        }

        // rest of your code here
    }

}


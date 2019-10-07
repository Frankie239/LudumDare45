using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Audio_instance;
    public AudioSource[] Song;
    public float timer;
    float timer2;
    AudioSource currentSong;
    AudioSource newSong;
    bool activatetimers;
    bool activatetimers2;
    AudioSource oldSong;
    private void Awake()
    {
        Audio_instance = this;
    }

    public void ChangeMusic(string color)
    {
        switch(color)
        {
            case "Violet": PlayTheSong(0); break;
            case "Yellow": PlayTheSong(1); break;
            case "Red": PlayTheSong(2); break;
            case "Orange": PlayTheSong(3); break;
            case "Blue": PlayTheSong(4); break;
            case "Green":PlayTheSong(5);  break;
               


        }
    }
    public void PlayTheSong(int index)
    {
        if (currentSong != null)
        {
            AnteriorCancion(currentSong);
        }

        currentSong = Song[index];
        currentSong.Play();
        currentSong.volume = 0.5f;
        activatetimers = true;
        //ChangeVolume();

        //currentSong = Song[indexSong];
    }

    public void AnteriorCancion(AudioSource audio)
    {
        oldSong = audio;
        oldSong.volume = 0.5f;
    }


    private void Start()
    {
        for (int i = 0; i < Song.Length; i++)
        {
            Song[i].volume = 0;
        }
        currentSong = null;


    }

    private void Update()
    {
        if (currentSong != null)
        {
            currentSong.volume = 0.5f;
        }

        if (activatetimers)
        {

            timer += Time.deltaTime * 45;
            timer2 -= Time.deltaTime * 45;
            ChangeVolume();

            if (timer>= 50)
            {
                activatetimers = false;
                timer = 0;
                timer2 = 50;
            }
            
        }

    }

    public void ChangeVolume()
    {
        float value = timer / 100;
        float value2 = timer2 / 100;

        currentSong.volume = value;
        if (oldSong != null)
        {
            oldSong.volume = value2;
        }
       

    }


}

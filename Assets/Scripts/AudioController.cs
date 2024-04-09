using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{

    [Header("Main Setting:")]
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVolume;

    public AudioSource musicAus;
    public AudioSource sfxAus;

    [Header("Game Sounds And Musics:")]
    public AudioClip shooting;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip[] bgmusiscs;

    public override void Start()
    {
        PlayMusic(bgmusiscs);
    }
    //1 sound
    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            aus.PlayOneShot(sound, sfxVolume);
        }
    }
    //Sound nhung ma mang
    public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }
        if (aus)
        {
            int randIdx = Random.Range(0, sounds.Length);

            if (sounds[randIdx] != null)
            {
                aus.PlayOneShot(sounds[randIdx], sfxVolume);
            }
        }
    }
    //1 music
    public void PlayMusic(AudioClip music, bool loop = true)
    {
        if (musicAus)
        {
            musicAus.clip = music;
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }
    }
    //Music nhung la mang
    public void PlayMusic(AudioClip[] musics, bool loop = true)
    {
        if (musicAus)
        {
            int randIdx = Random.Range(0, musics.Length);
            if (musics[randIdx] != null)
            {
                musicAus.clip = musics[randIdx];
                musicAus.loop = loop;
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }

    public void OnClickMusicOffBtn()
    {
        if (musicAus.isPlaying)
        {
            musicAus.Pause();
           
        }
        //MenuController.Ins.OnClickMusicOnBtn();
    }
    public void OnClickMusicOnBtn()
    {
        if (!musicAus.isPlaying)
        {
            musicAus.Play();
            
        }
        //MenuController.Ins.OnClickMusicOffBtn();
    }

    public void OnClickSoundOffBtn()
    {
        if (!sfxAus.mute)
        {
            sfxAus.mute = true;
            

        }
        //MenuController.Ins.OnClickSoundOnBtn();

    }
    public void OnClickSoundOnBtn()
    {
        if (sfxAus.mute)
        {
            sfxAus.mute = false;
            
        }
        //MenuController.Ins.OnClickSoundOffBtn();

    }

}

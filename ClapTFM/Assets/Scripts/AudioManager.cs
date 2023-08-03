using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    //Matriz musica 
    //public AudioSource[] music;
    public AudioSource[] sfx; //Efectos de sonido
    //Vídeos
    public VideoPlayer[] videos;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for(int i = 0; i < videos.Length; i++)
        {
            videos[i].gameObject.SetActive(false);
        }
    }
    //public void PlayMusic(int musicToPlay)
    //{
    //    music[musicToPlay].Play();
    //}
    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }
    public void StopSFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
    }
    public void PlayVideo(int videoToPlay)
    {
        videos[videoToPlay].gameObject.SetActive(true);
        videos[videoToPlay].Play();
    }
    public void StopVideo(int videoToPlay)
    {
        videos[videoToPlay].Stop();
        videos[videoToPlay].gameObject.SetActive(false);
    }
}
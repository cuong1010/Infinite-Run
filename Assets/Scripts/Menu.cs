using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public AudioSource aduio;
    void Start()
    {
        aduio.mute = !AudioManager.isMusic;
    }
    public void Play()
    {        
        SceneManager.LoadScene("Play");   
    }
    public void Music(bool value)
    {      
        aduio.mute = !value;
        AudioManager.isMusic = value;
    }
    public void Sound(bool value)
    {
        AudioManager.isSound = value;
    }
   public void Quit()
    {
        Application.Quit();
    }
   public void fullscreen(bool value)
   {
       Screen.fullScreen = value;
   }
   public void Pause()
   {
       Time.timeScale = 0;
   }
   public void Resume()
   {
       Time.timeScale = 1;
   }
}

using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    AudioSource[] soundList;
    public static bool isMusic=true,isSound=true;
	// Use this for initialization
	void Start () {
        soundList = GetComponents<AudioSource>();
        soundList[0].mute = !isMusic;
        for (int i = 1; i < soundList.Length; i++)
            soundList[i].mute = !isSound;
	}

    public void PlayMusic(string name)
    {
        foreach (var i in soundList)
        {
            if (i.clip.name.Equals(name)) i.Play();
        }
    }
    public void PlayMusic(int id)
    {
        soundList[id].Play();
    }
}

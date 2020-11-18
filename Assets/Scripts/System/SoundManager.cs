using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip sound;
}
public enum SoundType
{
    BGM,
    FX,
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : SingletonM<SoundManager>
{
    [SerializeField] private List<Audio> audioList;

    private Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();

    public Dictionary<string, AudioClip> GetAudio() => audios;

    private AudioSource BGMSource;
    private AudioSource FXSource;

    public float BGMVolume;
    public float FXVolume;

    private void OnEnable()
    {
        if (audioList.Count > 0)
        {
            foreach (var v in audioList)
            {
                audios.Add(v.name, v.sound);
            }
        }
        BGMSource = GetComponent<AudioSource>();
        FXSource = GetComponent<AudioSource>();

        StartSound();
    }

    void StartSound()
    {
        SetVolume(0.5f, SoundType.BGM);
        SetVolume(0.5f, SoundType.FX);

        PlayLoopSound("BGM");
    }


    public void SetVolume(float volume, SoundType type)
    {
        switch (type)
        {
            case SoundType.BGM:
                BGMVolume = volume;
                break;
            case SoundType.FX:
                FXVolume = volume;
                break;
            default:
                break;
        }
    }

    public void PlayOneShot(string name)
    {
        if (!GetAudio().ContainsKey(name))
            return;
        FXSource.volume = FXVolume;
        FXSource.PlayOneShot(GetAudio()[name]);
    }

    public void PlayLoopSound(string name)
    {
        if (!GetAudio().ContainsKey(name))
            return;
        BGMSource.volume = BGMVolume;
        BGMSource.clip = GetAudio()[name];
        BGMSource.loop = true;
        BGMSource.Play();
    }
}

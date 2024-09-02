using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMynager : MonoBehaviour
{
    [SerializeField] Toggle sountTgl;
    [SerializeField] Toggle musicTgl;

    [SerializeField] private AudioSource lose;
    [SerializeField] private AudioSource right;
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource wrong;

    [SerializeField] private AudioSource music;

    public static AudioMynager Instance;

    static bool SoundActive = true;
    static bool MusicActive = true;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        sountTgl.isOn = !SoundActive;
        musicTgl.isOn = !MusicActive;
    }

    public void SetSoundActive(bool _active)
    {
        SoundActive = !_active;
    }

    public void SetMusicActive(bool _active)
    {
        MusicActive = !_active;
        music.mute = !MusicActive;
    }

    public void Lose()
    {
        if(SoundActive) lose.Play();
    }

    public void Win()
    {
        if(SoundActive) win.Play();
    }

    public void Right()
    {
        if(SoundActive) right.Play();
    }

    public void Wrong()
    {
        if (SoundActive) wrong.Play();
    }
}

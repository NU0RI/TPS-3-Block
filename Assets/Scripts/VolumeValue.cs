using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource AudioSource;

    private float _ValueMusic = 1f;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AudioSource.volume = _ValueMusic;
    }

    public void setVolue(float vol)
    {
        _ValueMusic = vol;
    }
}

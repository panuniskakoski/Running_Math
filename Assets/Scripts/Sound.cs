﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 2f)]
    public float pitch;
    [Range(.1f, 3f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}

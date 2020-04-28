﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;

    public float volumeVariance;
    public float pitchVariance;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, .3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}

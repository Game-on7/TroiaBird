using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    [HideInInspector]
    public AudioSource src;

    [Range(0,1)]
    public float volume;
    [Range(-3,3)]
    public float pitch;
    public string name;
    public bool isLooping;
}

using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        foreach (Sound s in sounds)
        {
            AudioSource a = gameObject.AddComponent<AudioSource>();

            // Ýçine deðerleri set et
            a.clip = s.clip;
            a.volume = savedVolume;
            a.pitch = s.pitch;
            a.loop = s.isLooping;

            // Geri referans veriyoruz
            s.src = a;
        }
    }

    public void SetSFXVolume(float v)
    {
        foreach (Sound s in sounds)
        {
            s.src.volume = v;
        }
        PlayerPrefs.SetFloat("SFXVolume", v);

    }

    public void Play(string soundName)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == soundName)
            {
                s.src.Play();
                return;
            }
        }

        Debug.LogWarning("Sound Not Found: " + soundName);
    }
}

using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource gameSrc, radioSrc;
    [SerializeField]
    private Sound[] musics;

    private void Awake()
    {

        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        foreach (Sound s in musics)
        {
            AudioSource a = gameObject.AddComponent<AudioSource>();
            // Ýçine deðerleri set et
            a.clip = s.clip;
            a.volume = savedVolume;
            a.pitch = s.pitch;
            a.loop = s.isLooping;

            s.src = a;
            if (s.name == "gameSrc") gameSrc = a;
            if (s.name == "radioSrc") radioSrc = a;

        }
    }

    private void Start()
    {
        GameMusic();
        radioSrc.Play();
        gameSrc.Play();
    }

    public void SetMusicVolume(float v)
    {
        foreach (Sound s in musics)
        {
            s.src.volume = v;
        }
        PlayerPrefs.SetFloat("MusicVolume", v);
    }

    public void GameMusic()
    {
        gameSrc.volume = PlayerPrefs.GetFloat("MusicVolume", 1);
        radioSrc.volume = 0;
    }
    public void RadioMusic()
    {
        gameSrc.volume = 0;
        radioSrc.volume = PlayerPrefs.GetFloat("MusicVolume", 1);
    }
}

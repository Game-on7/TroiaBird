using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText, finalHighScoreTxt, highScoreText;
    private int highScore;
    private Coroutine rainbowCoroutine;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private MusicManager musicManager;

    void Start()
    {
        ShowStartUI();
        musicManager = Object.FindFirstObjectByType<MusicManager>();

        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSlider.value = savedMusicVolume;
        sfxSlider.value = savedSFXVolume;

        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    public void ShowStartUI()
    {
        StartPanel.SetActive(true);
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    private void OnMusicVolumeChanged(float value)
    {
        musicManager.SetMusicVolume(value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        SFXManager.instance.SetSFXVolume(value);
    }

    public void ShowGameUI()
    {
        GameManager.instance.StartGameButtonPressed();
        if (rainbowCoroutine != null) StopCoroutine(rainbowCoroutine);
        scoreText.text = "0";
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        GameManager.instance.GameOver();
        StartPanel.SetActive(false);
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (GameManager.instance.score > highScore)
        {
            highScore = GameManager.instance.score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "New High Score!:";
            if (rainbowCoroutine != null) StopCoroutine(rainbowCoroutine);
            rainbowCoroutine = StartCoroutine(RainbowEffect());
        }
        else
        {
            highScoreText.color = Color.HSVToRGB(62f / 360f, 0.70f, 0.99f);
            finalHighScoreTxt.color = Color.HSVToRGB(62f / 360f, 0.70f, 0.99f);
            highScoreText.text = "High Score:";
        }
        finalScoreText.text = GameManager.instance.score.ToString();
        finalHighScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    IEnumerator RainbowEffect()
    {
        float hue = 0f;
        float speed = 0.5f; // Renk deðiþim hýzý, buradan artýrýp azaltabilirsin

        while (true)
        {
            hue += Time.deltaTime * speed;
            if (hue > 1) hue = 0;

            highScoreText.color = Color.HSVToRGB(hue, 1f, 1f);
            finalHighScoreTxt.color = Color.HSVToRGB(hue, 1f, 1f);

            yield return null; // Bir sonraki frame'i bekle
        }
    }
}

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public TextMeshProUGUI scoreText;
public TextMeshProUGUI finalScoreText;


    void Start()
    {
        ShowStartUI();
    }

    public void ShowStartUI()
    {
        StartPanel.SetActive(true);
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

    public void ShowGameUI()
    {
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        StartPanel.SetActive(false);
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void ShowPauseUI()
    {
        PausePanel.SetActive(true);
    }

    public void HidePauseUI()
    {
        PausePanel.SetActive(false);
    }
    public void UpdateScore(int score)
    {
    scoreText.text = score.ToString();
    }

    public void ShowFinalScore(int score)
    {
    finalScoreText.text = "Score: " + score;
    }
}

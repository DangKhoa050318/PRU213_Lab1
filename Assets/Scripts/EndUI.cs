using UnityEngine;
using TMPro;

public class EndUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        if (GameManager.Instance != null)
            finalScoreText.text = "Final Score: " + GameManager.Instance.score;
    }

    public void Replay()
    {
        if (GameManager.Instance != null) GameManager.Instance.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
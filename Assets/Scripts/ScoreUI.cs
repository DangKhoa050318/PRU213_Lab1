using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start() { scoreText = GetComponent<TextMeshProUGUI>(); }
    void Update()
    {
        if (GameManager.Instance != null)
            scoreText.text = "Score: " + GameManager.Instance.score;
    }
}
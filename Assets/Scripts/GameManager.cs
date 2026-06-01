using UnityEngine;
using UnityEngine.SceneManagement;

// Quản lý tổng thể game: Điểm số và Chuyển cảnh
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Áp dụng Singleton Pattern
    public int score = 0;

    void Awake()
    {
        // Đảm bảo chỉ có 1 GameManager duy nhất tồn tại
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Đã thoát game!");
    }
}
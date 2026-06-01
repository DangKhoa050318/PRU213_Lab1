using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void PlayGame()
    {
        // GameManager có thể chưa tồn tại ở menu đầu tiên nên load trực tiếp
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void ToggleInstructions()
    {
        // Bật/tắt bảng hướng dẫn
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
    }
}
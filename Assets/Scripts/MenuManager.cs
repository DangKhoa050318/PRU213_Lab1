using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void ToggleInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
    }
}
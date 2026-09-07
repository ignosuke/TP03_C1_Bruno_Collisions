using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private UIPanel pausePanel;
    [SerializeField] private UIPanel settingsPanel;
    [SerializeField] private UIPanel creditsPanel;

    [Header("Pause Menu Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button pauseSettingsButton;
    [SerializeField] private Button pauseCreditsButton;
    [SerializeField] private Button pauseExitButton;
    [SerializeField] private Button pauseBackButton;

    [Header("Settings Menu Buttons")]
    [SerializeField] private Button settingsBackButton;

    [Header("Credits Menu Buttons")]
    [SerializeField] private Button creditsBackButton;

    private bool isPaused = false;
    private void Awake()
    {
        pausePanel.Close();
        settingsPanel.Close();
        creditsPanel.Close();

        // Listeners
        continueButton.onClick.AddListener(ResumeGame);
        pauseSettingsButton.onClick.AddListener(OpenSettings);
        pauseCreditsButton.onClick.AddListener(OpenCredits);
        pauseExitButton.onClick.AddListener(ExitGame);
        pauseBackButton.onClick.AddListener(BackToMenu);

        settingsBackButton.onClick.AddListener(CloseSettings);
        creditsBackButton.onClick.AddListener(CloseCredits);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void OnDestroy()
    {
        continueButton.onClick.RemoveAllListeners();
        pauseSettingsButton.onClick.RemoveAllListeners();
        pauseCreditsButton.onClick.RemoveAllListeners();
        pauseExitButton.onClick.RemoveAllListeners();
        pauseBackButton.onClick.RemoveAllListeners();
    }

    private void PauseGame()
    {
        pausePanel.Open();
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        pausePanel.Close();
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void OpenSettings()
    {
        settingsPanel.Open(); // se muestra encima de MainMenu o Pausa, sin cerrarlos
    }

    private void OpenCredits()
    {
        creditsPanel.Open();
    }


    private void CloseSettings()
    {
        settingsPanel.Close();
    }

    private void CloseCredits()
    {
        creditsPanel.Close();
    }
    private void BackToMenu()
    {
        pausePanel.Close();
        isPaused = false;

        SceneManager.LoadScene("MainMenuScene");
    }

    private void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{
    [SerializeField] private GameObject greetingScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject endScreen;

    private void OnEnable()
    {
        GameEvents.onGameEnded += ShowEndScreen;
    }

    private void OnDisable()
    {
        GameEvents.onGameEnded -= ShowEndScreen;
    }

    void Start()
    {
        ShowGreetingScreen();
    }

    public void ShowGreetingScreen()
    {
        HideAllScreens();
        greetingScreen.SetActive(true);
    }

    public void ShowGameScreen()
    {
        HideAllScreens();
        gameScreen.SetActive(true);
    }

    public void ShowEndScreen()
    {
        HideAllScreens();
        endScreen.SetActive(true);
    }

    private void HideAllScreens()
    {
        greetingScreen.SetActive(false);
        gameScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

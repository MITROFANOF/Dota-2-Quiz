using System.Runtime.InteropServices;
using UnityEngine;

public class Score : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void ShareHighScore(int value, bool hardmode);

    private const int scorePerAnswer = 1;
    private const int expertModeMultiplier = 2;

    public int Value { get; private set; } = 0;
    public int Highscore { get; private set; }

    private void Awake()
    {
        Highscore = PlayerPrefs.GetInt("Highscore");
    }

    private void OnEnable()
    {
        GameEvents.onCorrectAnswer += AddScore;
        GameEvents.onGameStarted += ResetScore;
    }

    private void OnDisable()
    {
        GameEvents.onCorrectAnswer -= AddScore;
        GameEvents.onGameStarted -= ResetScore;
    }

    private void AddScore()
    {
        Value += scorePerAnswer;

        if (ExpertMode.IsEnabled)
            Value += scorePerAnswer;

        AddComboScore();

        if (Value > Highscore)
        {
            Highscore = Value;
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
    }

    private void AddComboScore()
    {
        if (Combo.Count < 2) return;

        Value += Combo.Count;

        if (ExpertMode.IsEnabled)
            Value += Combo.Count * expertModeMultiplier;
    }

    private void ResetScore()
    {
        Value = 0;
    }

    [ContextMenu("Reset highscore")]
    private void ResetHighscore()
    {
        Highscore = 0;
        PlayerPrefs.SetInt("Highscore", Highscore);
    }

    public void ShareHighscore()
    {
        ShareHighScore(Highscore, ExpertMode.IsEnabled);
    }
}

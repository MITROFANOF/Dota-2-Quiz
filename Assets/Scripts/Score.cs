using UnityEngine;

public class Score : MonoBehaviour
{
    private const int scorePerAnswer = 1;
    private const int expertModeMultiplier = 2;

    public static int Count { get; private set; } = 0;

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
        Count += scorePerAnswer;

        if (Combo.Count < 2) return;

        Count += Combo.Count;

        if (ExpertMode.IsEnabled)
            Count += Combo.Count * expertModeMultiplier;

        print(Count);
    }

    private void ResetScore()
    {
        Count = 0;
    }
}

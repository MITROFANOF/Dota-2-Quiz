using UnityEngine;

public class Score : MonoBehaviour
{
    private const int scorePerAnswer = 1;
    private const int expertModeMultiplier = 2;

    public int Value { get; private set; } = 0;

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

        if (Combo.Count < 2) return;

        Value += Combo.Count;

        if (ExpertMode.IsEnabled)
            Value += Combo.Count * expertModeMultiplier;

        print(Value);
    }

    private void ResetScore()
    {
        Value = 0;
    }
}

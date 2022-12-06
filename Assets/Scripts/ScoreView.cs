using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI scoreInGameLabel;
    [SerializeField] private Shaker shaker;
    [SerializeField] private Score score;

    [SerializeField] private int shakeIntensity = 1;

    private void OnEnable()
    {
        GameEvents.onGameEnded += ShowScore;
        GameEvents.onCorrectAnswer += ShowScoreInGame;
    }

    private void OnDisable()
    {
        GameEvents.onGameEnded -= ShowScore;
        GameEvents.onCorrectAnswer -= ShowScoreInGame;
    }

    private void ShowScore()
    {
        scoreLabel.text = $"Твой результат: {score.Value}\nЛучший результат: {score.Highscore}";
    }

    private void ShowScoreInGame()
    {
        scoreInGameLabel.text = score.Value.ToString();
        shaker.Shake(shakeIntensity);
    }
}

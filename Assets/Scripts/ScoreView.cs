using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private Highscore highscore;
    [SerializeField] private Score score;

    private void OnEnable()
    {
        GameEvents.onGameEnded += ShowScore;
    }

    private void OnDisable()
    {
        GameEvents.onGameEnded -= ShowScore;
    }

    private void ShowScore()
    {
        scoreLabel.text = $"Твой результат: {score.Value}\nЛучший результат: {highscore.Value}";
    }
}

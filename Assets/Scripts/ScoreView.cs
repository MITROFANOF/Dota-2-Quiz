using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;

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
        scoreLabel.text = $"Твой результат: {Score.Count}";
    }
}

using UnityEngine;

public class Highscore : MonoBehaviour
{
    public int Value { get; private set; } = 0;

    [SerializeField] private Score score;

    public static Highscore Instance;

    private void OnEnable()
    {
        GameEvents.onGameEnded += CheckHighscore;
    } 
    
    private void OnDisable()
    {
        GameEvents.onGameEnded -= CheckHighscore;
    }

    private void CheckHighscore()
    {
        if (score.Value > Value)
            Value = score.Value;
    }
}

using TMPro;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboLabel;
    [SerializeField] private Shaker shaker;

    [SerializeField] private float fontSize = 128f;
    [SerializeField] private float fontSizeBooster = 2f;

    [SerializeField] private float maxColorIntensityAnswers = 30f;

    public static int Count { get; private set; } = 0;

    private void Awake()
    { 
        ResetComboCounter();
    }

    private void OnEnable()
    {
        GameEvents.onWrongAnswer += ResetComboCounter;
        GameEvents.onCorrectAnswer += AddComboCounter;
    }

    private void OnDisable()
    {
        GameEvents.onWrongAnswer -= ResetComboCounter;
        GameEvents.onCorrectAnswer -= AddComboCounter;
    }

    public void AddComboCounter()
    {
        Count++;

        if (Count >= 2)
            comboLabel.SetText($"X{Count}");

        shaker.Shake(Count);

        comboLabel.fontSize = fontSize + fontSizeBooster * Count;
        comboLabel.color = new Color(1f, 1f - Count / maxColorIntensityAnswers, 1f - Count / maxColorIntensityAnswers);
    }

    public void ResetComboCounter()
    {
        Count = 0;
        comboLabel.SetText("");
        comboLabel.color = Color.white;
    }
}

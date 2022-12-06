using TMPro;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboLabel;

    [SerializeField] private float fontSize = 128f;
    [SerializeField] private float fontSizeBooster = 2f;

    [SerializeField] private float shakeIntensity = 2f;
    [SerializeField] private float maxShakeIntensity = 5f;
    [SerializeField] float shakeIntensityDropAmount = 0.5f;
    [SerializeField] float baseShakeIntensity = 0.2f;
    [SerializeField] float shakeIntensityBooster = 0.2f;

    [SerializeField] private float maxColorIntensityAnswers = 30f;

    public static int Count { get; private set; } = 0;

    private Vector3 baseLocalPosition;

    private void Awake()
    {
        baseLocalPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        GameEvents.onGameStarted += ResetComboCounter;
        GameEvents.onWrongAnswer += ResetComboCounter;
        GameEvents.onCorrectAnswer += AddComboCounter;
    }

    private void OnDisable()
    {
        GameEvents.onGameStarted -= ResetComboCounter;
        GameEvents.onWrongAnswer -= ResetComboCounter;
        GameEvents.onCorrectAnswer -= AddComboCounter;
    }

    public void AddComboCounter()
    {
        Count++;

        if(Count >= 2)
            comboLabel.SetText($"X{Count}");

        shakeIntensity = Mathf.Clamp(baseShakeIntensity + shakeIntensityBooster * Count, baseShakeIntensity, maxShakeIntensity);

        comboLabel.fontSize = fontSize + fontSizeBooster * Count;
        comboLabel.color = new Color(1f, 1f - Count / maxColorIntensityAnswers, 1f - Count / maxColorIntensityAnswers);
    }

    public void ResetComboCounter()
    {
        Count = 0;
        comboLabel.SetText("");
        comboLabel.color = Color.white;
    }

    private void Update()
    {
        if (shakeIntensity > 0)
        {
            shakeIntensity -= shakeIntensityDropAmount * Time.deltaTime;

            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            transform.localPosition = baseLocalPosition + randomDirection * shakeIntensity;
        }
    }
}

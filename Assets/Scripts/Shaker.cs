using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] private float shakeIntensity = 2f;
    [SerializeField] private float maxShakeIntensity = 5f;
    [SerializeField] float shakeIntensityDropAmount = 0.5f;
    [SerializeField] float baseShakeIntensity = 0.2f;
    [SerializeField] float shakeIntensityBooster = 0.2f;

    private Vector3 baseLocalPosition;

    private void Start()
    {
        baseLocalPosition = transform.localPosition;
    }

    public void Shake(int value)
    {
        shakeIntensity = Mathf.Clamp(baseShakeIntensity + shakeIntensityBooster * value, baseShakeIntensity, maxShakeIntensity);
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
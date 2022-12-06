using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerTimer : MonoBehaviour
{
    [SerializeField] private Image timerLoop;
    [SerializeField] private Image timerArrow;

    [SerializeField] private Score score;

    [SerializeField] private float startTime = 30f;
    [SerializeField] private float remainingTime;
    [SerializeField] private float extraTimePerAnswer = 3f;

    private void OnEnable()
    {
        GameEvents.onCorrectAnswer += AddTime;
    }

    private void OnDisable()
    {
        GameEvents.onCorrectAnswer -= AddTime;
    }

    private void Start()
    {
        remainingTime = startTime;
    }

    private void Update()
    {
        if (remainingTime <= 0)
        {
            GameEvents.onGameEnded?.Invoke();
            return;
        }

        remainingTime -= Time.deltaTime;
        timerArrow.transform.eulerAngles = new Vector3(0f, 0f, remainingTime * -360f / startTime);
        timerLoop.fillAmount = remainingTime / startTime;
    }

    public void AddTime()
    {
        //Формула прибавки времени в зависимости от заработанных очков
        remainingTime += extraTimePerAnswer - Mathf.Clamp(score.Value / (5f * extraTimePerAnswer), 0, extraTimePerAnswer) + 1.5f;
        startTime = remainingTime;
    }
}

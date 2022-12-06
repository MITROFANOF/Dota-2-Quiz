using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuizGameplay : MonoBehaviour
{
    [SerializeField] private QuizView quizView;
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private float nextQuestionDelay = 1f;

    private void Start()
    {
        quizView.ShowQuiz();
    }

    public void CalculateScore(int id)
    {
        GameEvents.onAnswer?.Invoke();

        SetButtonsInteractable(false);

        if (id == quizView.GetCorrectAnswerId())
        {
            GameEvents.onCorrectAnswer?.Invoke();
        }
        else
        {
            GameEvents.onWrongAnswer?.Invoke();
        }

        quizView.ShowCorrectAnswer();

        StartCoroutine(NextQuestionDelay(nextQuestionDelay));
    }

    private void SetButtonsInteractable(bool state)
    {
        foreach (var button in answerButtons)
        {
            button.interactable = state;
        }
    }

    private IEnumerator NextQuestionDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        quizView.ShowQuiz();

        SetButtonsInteractable(true);
    }
}

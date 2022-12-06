using UnityEngine;
using UnityEngine.UI;

public class QuizView : MonoBehaviour
{
    [SerializeField] private Image question;
    [SerializeField] private Image[] answers;
    [SerializeField] private QuizMaker quizMaker;

    private Quiz quiz;

    public int GetCorrectAnswerId()
    {
        return quiz.CorrectAnswerId;
    }

    public void ShowQuiz()
    {
        quiz = quizMaker.MakeQuiz();

        ResetColors();

        question.sprite = quiz.Question;

        for (int i = 0; i < quiz.AnswersCount; i++)
            answers[i].sprite = quiz.GetAnswer(i);
    }

    public void ShowCorrectAnswer()
    {
        for (int i = 0; i < quiz.AnswersCount; i++)
            answers[i].color = Color.red;

        answers[GetCorrectAnswerId()].color = Color.green;
    }

    private void ResetColors()
    {
        for (int i = 0; i < quiz.AnswersCount; i++)
            answers[i].color = Color.white;
    }
}

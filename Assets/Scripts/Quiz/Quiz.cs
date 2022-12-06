using UnityEngine;

public class Quiz
{
    private Sprite question;
    private Sprite[] answers;
    public int CorrectAnswerId { get; private set; }
    public int AnswersCount => answers.Length;

    public Quiz(Sprite question, Sprite[] answers, int correctAnswerId)
    {
        this.question = question;
        this.answers = answers;
        this.CorrectAnswerId = correctAnswerId;
    }

    public Sprite Question => question;

    public Sprite GetAnswer(int id) => answers[id];
}

using UnityEngine;

public class GameSounds : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource wrongAnswerSound;
    [SerializeField] private AudioSource correctAnswerSound;
    [SerializeField] private AudioSource endSound;

    private void OnEnable()
    {
        GameEvents.onWrongAnswer += WrongAnswer;
        GameEvents.onCorrectAnswer += CorrectAnswer;
        GameEvents.onGameEnded += EndSound;
        GameEvents.onGameStarted += PlayMusic;
    }

    private void OnDisable()
    {
        GameEvents.onWrongAnswer -= WrongAnswer;
        GameEvents.onCorrectAnswer -= CorrectAnswer;
        GameEvents.onGameEnded -= EndSound;
        GameEvents.onGameStarted -= PlayMusic;
    }

    public void PlayMusic() => music.Play();

    public void WrongAnswer() => wrongAnswerSound.Play();

    public void CorrectAnswer() => correctAnswerSound.Play();

    public void EndSound() => endSound.Play();
}

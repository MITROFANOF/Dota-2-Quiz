using UnityEngine;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        GameEvents.onGameStarted?.Invoke();
    }
}

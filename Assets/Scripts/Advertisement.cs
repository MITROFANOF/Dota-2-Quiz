using System.Runtime.InteropServices;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void ShowFullscreenAdv();

    private void OnEnable()
    {
        GameEvents.onGameEnded += ShowFullscreenAdv;
    }

    private void OnDisable()
    {
        GameEvents.onGameEnded -= ShowFullscreenAdv;
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private VolumeView volumeView;

    private const float Muted = -60f;
    private float volume = 0f;
    private float lastVolume = 0f;

    private bool isMuted = false;

    public void Change(float value)
    {
        isMuted = value == 0;
        volume = Mathf.Lerp(Muted, 0f, value);
        SetMasterVolume();
        volumeView.SetIcon(isMuted);
    }

    private void SetMasterVolume() => mixer.SetFloat("MasterVolume", volume);

    public void ToggleMute()
    {
        if (isMuted)
        {
            volume = lastVolume;
            volumeView.SetSliderValue(Mathf.InverseLerp(Muted, 0f, lastVolume));
        }
        else
        {
            lastVolume = volume;
            volume = Muted;
            volumeView.SetSliderValue(0f);
        }
        SetMasterVolume();
        volumeView.SetIcon(isMuted);
    }
}

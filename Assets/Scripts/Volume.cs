using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private VolumeView volumeView;

    private const float Muted = -80f;
    private float volume = 0f;
    private float lastVolume = 0f;

    private bool isMuted = false;

    private void Start()
    {
        mixer.GetFloat("MasterVolume", out float masterVolume);
        volume = Mathf.InverseLerp(Muted, 0f, masterVolume);
        volumeView.SetSliderValue(volume);
    }

    public void Change(float value)
    {
        isMuted = value == 0;
        volume = Mathf.Lerp(Muted, 0f, value);
        SetMasterVolume(volume);
        volumeView.SetIcon(isMuted);
    }

    private void SetMasterVolume(float value) => mixer.SetFloat("MasterVolume", value);

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
        SetMasterVolume(volume);
        volumeView.SetIcon(isMuted);
    }
}

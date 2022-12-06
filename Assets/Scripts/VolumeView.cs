using UnityEngine;
using UnityEngine.UI;

public class VolumeView : MonoBehaviour
{
    [SerializeField] private Sprite mutedSprite;
    [SerializeField] private Sprite unmutedSprite;

    [SerializeField] private Image volumeIcon;
    [SerializeField] private Slider volumeSlider;


    public void SetIcon(bool muted)
    {
        if (muted)
            volumeIcon.sprite = mutedSprite;
        else
            volumeIcon.sprite = unmutedSprite;
    }

    public void SetSliderValue(float value)
    {
        volumeSlider.value = value;
    }
}

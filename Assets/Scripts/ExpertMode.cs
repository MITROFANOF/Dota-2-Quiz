using UnityEngine;
using UnityEngine.UI;

public class ExpertMode : MonoBehaviour
{
    [SerializeField] private Image question;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Material grayscaleMaterial;

    public static bool IsEnabled;

    public void Switch()
    {
        IsEnabled = toggle.isOn;

        if (toggle.isOn)
            question.material = grayscaleMaterial;
        else
            question.material = null;
    }
}

public class ExpertModeM
{

}
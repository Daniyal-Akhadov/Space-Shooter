using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private Gradient _gradient;

    public void SetMatHealth(float value)
    {
        _slider.maxValue = value;
        _slider.value = value;
        _fill.color = _gradient.Evaluate(1);
    }

    public void SetHealth(float value)
    {
        _slider.value = value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}

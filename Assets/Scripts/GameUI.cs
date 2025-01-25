using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    private void OnEnable()
    {
        slider.maxValue = 10.0f;
        slider.value = 10.0f;

        Health.OnHealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        Health.OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        slider.value = health;
    }
}

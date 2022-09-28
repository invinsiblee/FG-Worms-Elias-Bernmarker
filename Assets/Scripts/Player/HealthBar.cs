using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = 100;
        slider.value = 100;
    }

    public void SetCurrentHealth(int health)
    {
        slider.value = health;
    }
}

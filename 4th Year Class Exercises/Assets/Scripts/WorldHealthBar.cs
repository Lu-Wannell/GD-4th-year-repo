using UnityEngine;
using UnityEngine.UI;

public class WorldHealthBar : MonoBehaviour
{
    [SerializeField] private Image Fill;              //drag fill image here
    [SerializeField] private NetworkHealth health;    //can auto-find if left empty

    private void OnEnable() //When the NetworkVariable changes, call my OnHealthChangeMethod;
    {
        if (health != null)
        {
            health.Health.OnValueChanged += OnHealthChanged;
        }
        UpdateFill();
    }

    private void OnDisable()
    {
        if (health != null)
        {
            health.Health.OnValueChanged -= OnHealthChanged;   //This unsubscribes from event / stops listening
        }
    }
    private void OnHealthChanged(int oldValue, int newValue)
    {
        UpdateFill();
    }

    private void UpdateFill()
    {
        if (!Fill || health == null) return;
        Fill.fillAmount = health.Health01; //the Health01 return float in NetworkHealth
    }

}

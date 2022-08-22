using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.maxValue = GameManager.instance.remainingTime;
        slider.value = GameManager.instance.remainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.instance.remainingTime;
    }
}

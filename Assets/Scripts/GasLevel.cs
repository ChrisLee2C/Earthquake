using UnityEngine;
using UnityEngine.UI;

public class GasLevel : MonoBehaviour
{
    public float gasLevelModifier = 0;
    public Image colouredTrigger;
    private Slider gasSlider;
    private float increaseLevel = 0.07f;
    private float decreaseLevel = 0.1f;

    private void Awake()
    {
        gasSlider = GetComponent<Slider>();
    }

    void DropGasLevel()
    {
        if(colouredTrigger.fillAmount >= 1)
        {
            gasSlider.value -= decreaseLevel * Time.deltaTime;
        }
    }

    public void AddGasLevel()
    {
        gasSlider.value += increaseLevel * Time.deltaTime * gasLevelModifier;
    }

    private void Update()
    {
        if (GameManager.instance.isGameStart == true){
            AddGasLevel();
            DropGasLevel();
        }
        if (gasSlider.value <= 0)
        {
            gasSlider.value = 0;
            GameManager.instance.ChangeGameState(GameManager.EndGameState.PowerOutage);
        }
        else if(gasSlider.value >= 1)
        {
            gasSlider.value = 1;
        }
    }
}

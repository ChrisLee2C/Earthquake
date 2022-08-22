using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public float levelModifier = 0;
    private Slider slider;
    private float increaseLevel = 0.07f;
    private float decreaseLevel = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        if (GameManager.instance.isGameStart == true)
        {
            GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Off);
        }
    }

    void DropLevel()
    {
        slider.value -= decreaseLevel * Time.deltaTime;
    }

    public void AddLevel()
    {
        slider.value += increaseLevel * Time.deltaTime * levelModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart == true)
        {
            AddLevel();
            DropLevel();
        }
        if (slider.value > 1)
        {
            GameManager.instance.ChangeGameState(GameManager.EndGameState.Earthquake);
        }
    }
}

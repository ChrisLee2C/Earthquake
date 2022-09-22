using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public float levelModifier = 0;
    public Image largeFracture;
    private Slider slider;
    private float increaseLevel = 0.015f;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        if (GameManager.instance.isGameStart == true)
        {
            GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Off);
        }
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
            if (largeFracture.fillAmount >= 1)
            {
                AddLevel();
            }
        }
        if (slider.value > 1)
        {
            GameManager.instance.ChangeGameState(GameManager.EndGameState.Earthquake);
        }
    }
}

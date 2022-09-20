using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    private int nextPress = 0;

    public void IncreaseLevel()
    {
        nextPress++;
        if(nextPress > 3)
        {
            nextPress = 0;
        }
        switch (nextPress)
        {
            case 0:
                GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Off);
                break;
            case 1:
                GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Low);
                break;
            case 2:
                GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Medium);
                break;
            case 3:
                GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.High);
                break;
        }
    }
}

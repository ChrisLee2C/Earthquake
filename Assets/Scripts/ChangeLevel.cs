using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public void ChangeOff()
    {
        GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Off);
    }

    public void ChangeLow()
    {
        GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Low);
    }

    public void ChangeMedium()
    {
        GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.Medium);
    }

    public void ChangeHigh()
    {
        GameManager.instance.ChangeWaterLevel(GameManager.WaterLevelState.High);
    }
}

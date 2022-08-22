using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() { instance = this; }

    public float remainingTime = 30f;
    public float delay = 5f;
    public bool isGameStart = false;
    public enum EndGameState { PowerOutage, Earthquake, Success }
    public enum WaterLevelState { Off, Low, Medium, High }
    public WaterLevelState currentWaterLevelState;

    [SerializeField] private Level waterLevelScript;
    [SerializeField] private Level magnitudeLevelScript;
    [SerializeField] private GasLevel gasLevelScript;
    [SerializeField] private EndImage endImageScript;
    [SerializeField] private PointerRotate pointerRotateScript;

    private EndGameState endGameState;

    public void GameStart() { isGameStart = true; }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart == false) { return; } else { CountDown(); }
    }

    public void ChangeWaterLevel(WaterLevelState newWaterLevelState)
    {
        currentWaterLevelState = newWaterLevelState;
        switch (currentWaterLevelState)
        {
            case WaterLevelState.Off:
                waterLevelScript.levelModifier = 0;
                magnitudeLevelScript.levelModifier = 0;
                gasLevelScript.gasLevelModifier = 0;
                pointerRotateScript.SetRotationToTextObject(0);
                break;
            case WaterLevelState.Low:
                waterLevelScript.levelModifier = 2f;
                magnitudeLevelScript.levelModifier = 2f;
                gasLevelScript.gasLevelModifier = 2f;
                pointerRotateScript.SetRotationToTextObject(1);
                break;
            case WaterLevelState.Medium:
                waterLevelScript.levelModifier = 4f;
                magnitudeLevelScript.levelModifier = 4f;
                gasLevelScript.gasLevelModifier = 4f;
                pointerRotateScript.SetRotationToTextObject(2);
                break;
            case WaterLevelState.High:
                waterLevelScript.levelModifier = 8f;
                magnitudeLevelScript.levelModifier = 8f;
                gasLevelScript.gasLevelModifier = 8f;
                pointerRotateScript.SetRotationToTextObject(3);
                break;
        }
    }

    public void ChangeGameState(EndGameState endGameState)
    {
        switch (endGameState)
        {
            case (EndGameState.PowerOutage):
                endImageScript.SetEndGameObject(endImageScript.endGameObject[0]);
                endImageScript.gameObject.SetActive(true);
                isGameStart = false;
                break;
            case (EndGameState.Earthquake):
                endImageScript.SetEndGameObject(endImageScript.endGameObject[1]);
                endImageScript.gameObject.SetActive(true);
                isGameStart = false;
                break;
            case (EndGameState.Success):
                endImageScript.SetEndGameObject(endImageScript.endGameObject[2]);
                endImageScript.gameObject.SetActive(true);
                isGameStart = false;
                break;
        }
    }

    void CountDown()
    {
        remainingTime -= 1f * Time.deltaTime;
        if (remainingTime <= 0)
        {
            remainingTime = 0f;
            isGameStart = false;
            ChangeGameState(EndGameState.Success);
        }
    }

    public void RestartGame() { StartCoroutine(Restart()); }

    IEnumerator Restart()
    {
        if (isGameStart == false)
        {
            isGameStart = true;
            yield return new WaitForSeconds(GameManager.instance.delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

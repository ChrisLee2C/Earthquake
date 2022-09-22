using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private HTTPPost hTTPPost;
    private Slider magnitude;
    private void Awake()
    {
        instance = this;
        hTTPPost = FindObjectOfType<HTTPPost>();
        magnitude = magnitudeLevelScript.GetComponent<Slider>();
    }

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
    [SerializeField] private WaterPipe waterPipeScript;

    private EndGameState endGameState;

    public void GameStart() { isGameStart = true; }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart == false)
        {
            return;
        }
        else
        {
            CountDown();
        }
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
                waterPipeScript.waterLevelModifier = 0f;
                break;
            case WaterLevelState.Low:
                waterLevelScript.levelModifier = 1f;
                magnitudeLevelScript.levelModifier = 1f;
                gasLevelScript.gasLevelModifier = 1f;
                pointerRotateScript.SetRotationToTextObject(1);
                waterPipeScript.waterLevelModifier = 0.3f;
                break;
            case WaterLevelState.Medium:
                waterLevelScript.levelModifier = 4f;
                magnitudeLevelScript.levelModifier = 4f;
                gasLevelScript.gasLevelModifier = 10f;
                pointerRotateScript.SetRotationToTextObject(2);
                waterPipeScript.waterLevelModifier = 0.5f;
                break;
            case WaterLevelState.High:
                waterLevelScript.levelModifier = 8f;
                magnitudeLevelScript.levelModifier = 8f;
                gasLevelScript.gasLevelModifier = 12f;
                pointerRotateScript.SetRotationToTextObject(3);
                waterPipeScript.waterLevelModifier = 0.7f;
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
                hTTPPost.Post();
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
            if (magnitude.value < 0.85)
            {
                ChangeGameState(EndGameState.Success);
            }
            else
            {
                ChangeGameState(EndGameState.Earthquake);
            }
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

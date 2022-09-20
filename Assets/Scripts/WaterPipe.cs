using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPipe : MonoBehaviour
{
    public List<GameObject> ballParticles;
    public Image waterPipe;
    public Image smallFractures;
    public Image largeFractures;
    public Slider magnitude;
    public float waterLevelModifier = 0f;

    private void AddWater()
    {
        if (smallFractures.fillAmount >= 1)
        {
            largeFractures.fillAmount += waterLevelModifier * Time.deltaTime;
        }
        else if (waterPipe.fillAmount >= 1)
        {
            smallFractures.fillAmount += waterLevelModifier * Time.deltaTime;
        }
        else
        {
            waterPipe.fillAmount += waterLevelModifier * Time.deltaTime;
        }
    }

    private void ShowBalls()
    {
        if (magnitude.value >= 0.9)
        {
            ballParticles[3].SetActive(true);
        }
        else if(magnitude.value >= 0.7)
        {
            ballParticles[2].SetActive(true);
            ballParticles[3].SetActive(false);
        }
        else if(magnitude.value >= 0.5)
        {
            ballParticles[1].SetActive(true);
            ballParticles[2].SetActive(false);
            ballParticles[3].SetActive(false);
        }
        else if (magnitude.value >= 0.2)
        {
            ballParticles[0].SetActive(true);
            ballParticles[1].SetActive(false);
            ballParticles[2].SetActive(false);
            ballParticles[3].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameStart == true)
        {
            AddWater();
            ShowBalls();
        }
    }
}

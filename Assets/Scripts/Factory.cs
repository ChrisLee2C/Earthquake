using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    public GameObject clouds;
    public GameObject shake;
    public GameObject spawner;
    public Slider magnitude;
    public Image factory;
    public Sprite[] image;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart == true)
        {
            clouds.SetActive(true);
            if (magnitude.value >= 0.9)
            {
                spawner.SetActive(true);
                factory.sprite = image[1];
                shake.SetActive(false);
            }
            else if (magnitude.value >= 0.7)
            {
                factory.sprite = image[0];
                spawner.SetActive(false);
                shake.SetActive(true);
            }
            else
            {
                spawner.SetActive(false);
                factory.sprite = image[0];
                shake.SetActive(false);
            }
        }
        else
        {
            spawner.SetActive(false);
        }
    }
}

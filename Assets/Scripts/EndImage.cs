using UnityEngine;
using UnityEngine.UI;

public class EndImage : MonoBehaviour
{
    public EndImageScriptableObjects[] endGameObject;
    [SerializeField] private Image image;
    [SerializeField] private Text text;

    public void SetEndGameObject(EndImageScriptableObjects endGameObject)
    {
        image.sprite = endGameObject.endGameImage;
        text.text = endGameObject.endGameText1 + "\n" + endGameObject.endGameText2;
    } 
}

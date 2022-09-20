using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private RectTransform canvas;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localPosition.x >= canvas.rect.width / 2)
        {
            gameObject.transform.localPosition -= new Vector3(2,0,0) * Time.deltaTime;
        }
    }
}

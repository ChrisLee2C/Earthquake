using UnityEngine;

public class PointerRotate : MonoBehaviour
{
    private GameObject currentTextObject;

    [SerializeField] private GameObject[] textObjects;

    private void Awake()
    {
        currentTextObject = textObjects[0];
    }

    private void Update()
    {
        Rotate();
    }

    public void SetRotationToTextObject(int index)
    {
        currentTextObject = textObjects[index];
    }

    private void Rotate()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, currentTextObject.transform.localRotation, Time.deltaTime * 5);
    }
}

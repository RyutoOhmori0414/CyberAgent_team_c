using UnityEngine;
using UnityEngine.UI;

public class RotateCountView : MonoBehaviour
{
    [SerializeField] private Text textComponent;

    public void SetCount(int count)
    {
        textComponent.text = count.ToString();
    }
}
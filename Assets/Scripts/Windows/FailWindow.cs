using UnityEngine;

public class FailWindow : Window
{
    [SerializeField] private GameObject windowObject;
        
    public override void Open()
    {
        windowObject.SetActive(true);
    }

    public override void Close()
    {
        windowObject.SetActive(false);
    }
}
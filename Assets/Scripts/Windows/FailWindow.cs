using System;
using UnityEngine;

public class FailWindow : Window
{
    [SerializeField] private GameObject windowObject;

    private void Start()
    {
        windowObject.SetActive(false);
    }

    public override void Open()
    {
        windowObject.SetActive(true);
    }

    public override void Close()
    {
        windowObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchableWall : MonoBehaviour
{
    [SerializeField]
    SwitchObject _switchObject;
    [Tooltip("スイッチが押された際のスイッチの移動"),SerializeField]
    Vector3 _position;

    private void Start()
    {
        _switchObject.PressState.Skip(1).Subscribe(x =>
        {
            if (x)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }).AddTo(this);
    }

    void Show ()
    {
        this.transform.position += _position;
    }

    void Hide ()
    {
        this.transform.position -= _position;
    }
}

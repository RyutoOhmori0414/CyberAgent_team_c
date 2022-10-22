using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchableWall : MonoBehaviour
{
    SwitchObject _switchObject;
    [Tooltip("�X�C�b�`�������ꂽ�ۂ̃X�C�b�`�̈ړ�"),SerializeField]
    Vector3 _position;

    private void Start()
    {
        _switchObject.PressState.Subscribe(x =>
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

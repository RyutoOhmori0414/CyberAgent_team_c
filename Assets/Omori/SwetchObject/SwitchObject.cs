using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchObject : MonoBehaviour
{
    ReactiveProperty<bool> _pressState;
    public IReadOnlyReactiveProperty<bool> PressState;

    private void OnTriggerEnter(Collider other)
    {
        // �X�C�b�`�ɐG��邽�т�True��False��؂�ւ���
        _pressState.Value = !_pressState.Value;
    }
}

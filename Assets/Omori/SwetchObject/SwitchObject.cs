using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchObject : MonoBehaviour
{
    ReactiveProperty<bool> _pressState = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> PressState => _pressState;

    private void OnTriggerEnter(Collider other)
    {
        // �X�C�b�`�ɐG��邽�т�True��False��؂�ւ���
        _pressState.Value = !_pressState.Value;
    }
}

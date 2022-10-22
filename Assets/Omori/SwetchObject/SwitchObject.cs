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
        // スイッチに触れるたびにTrueとFalseを切り替える
        _pressState.Value = !_pressState.Value;
    }
}

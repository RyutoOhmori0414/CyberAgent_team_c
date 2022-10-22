using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IMoveable, ITeleportable
{
    private Rigidbody _rig = default;
    private static Subject<Unit> _deathSubject = new Subject<Unit>();
    public static IObservable<Unit> OnDead => _deathSubject;

    private bool _isMove = true;

    private void Start()
    {
        MoveObjectHolder.AddObject(this);
        _rig = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Death();
        }
    }
    private void Death()
    {
        MoveObjectHolder.RemoveObject(this);
        _deathSubject.OnNext(Unit.Default);
        Destroy(this.gameObject);
    }

    public void StartMovement()
    {
        if (!_isMove)
        {
            _isMove = true;
            _rig.WakeUp();
            _rig.velocity = Vector3.zero;
        }
    }

    public void StopMovement()
    {
        if (_isMove)
        {
            _isMove = false;
            _rig.Sleep();
        }
    }

    public void TeleportTo(Transform transform)
    {
        this.transform.position = transform.position;
    }

    public Vector3 GetVelocity()
    {
        return _rig.velocity;
    }
}

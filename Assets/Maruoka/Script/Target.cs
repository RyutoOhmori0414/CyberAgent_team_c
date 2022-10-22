using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// ターゲットを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour, IMoveable, ITeleportable
{
    private Rigidbody _rig = default;
    private static Subject<Unit> _deathSubject = new Subject<Unit>();
    public static IObservable<Unit> OnDead => _deathSubject;

    [SerializeField]
    MoveObjectHolder _moveObjectHolder = default;

    private bool _isMove = true;

    private void Start()
    {
        if (_moveObjectHolder == null)
        {
            Debug.LogError("MoveObjectHolderをアサインしてください！");
#if UNITY_EDITOR
            //UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            _moveObjectHolder.AddObject(this);
        }

        _rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Moveストップのテスト
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopMovement();
        }
        // Moveスタートのテスト
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartMovement();
        }
    }
    private void FixedUpdate()
    {
        // 落下判定
        if (transform.position.y < 0.0f)
        {
            Death();
        }
    }
    private void Death()
    {
        //_moveObjectHolder.RemoveObject(this);
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
}

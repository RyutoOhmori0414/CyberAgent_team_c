using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UniRx;

public class BoardRotater : MonoBehaviour
{
    [SerializeField] private MoveObjectHolder moveObjectHolder;
    [SerializeField] private Transform board;
    [SerializeField] private float rotateTime = 0.5f;
    
    private Subject<Unit> _rotateSubject;
    public IObservable<Unit> OnRotate => _rotateSubject;

    private int _remainedRotateCount;
    private bool _canInput;
    private CancellationTokenSource _cts;

    private void Start()
    {
        _canInput = true;
        _cts = new CancellationTokenSource();
    }

    private void Update()
    {
        if (StageStateHolder.StageState is StageState.AfterGame) return;
        if (!_canInput) return;
        if (_remainedRotateCount <= 0) return;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 左回転
            RotateLeft(_cts.Token).Forget();
            _rotateSubject.OnNext(Unit.Default);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // 右回転
            RotateRight(_cts.Token).Forget();
            _rotateSubject.OnNext(Unit.Default);
        }
    }

    public void SetRotateCount(int count)
    {
        _remainedRotateCount = count;
    }
    
    private async UniTaskVoid RotateRight(CancellationToken token)
    {
        StopMovement();
        Rotate(-90);
        await UniTask.Delay(TimeSpan.FromSeconds(rotateTime), cancellationToken: token);
        StartMovement();
    }

    private async UniTaskVoid RotateLeft(CancellationToken token)
    {
        StopMovement();
        Rotate(90);
        await UniTask.Delay(TimeSpan.FromSeconds(rotateTime), cancellationToken: token);
        StartMovement();
    }

    private void Rotate(float angle)
    {
        _remainedRotateCount--;
        // カメラは+Z方向
        var currentAngle = board.rotation.eulerAngles;
        var targetAngle = currentAngle + new Vector3(0, 0, angle);
        board.DOLocalRotate(targetAngle, rotateTime).SetEase(Ease.InOutCirc);
    }

    private void StopMovement()
    {
        _canInput = false;
        var moveables = moveObjectHolder.GetCollection();
        foreach (var moveable in moveables)
        {
            moveable.StopMovement();
        }
    }
    
    private void StartMovement()
    {
        _canInput = true;
        var moveables = moveObjectHolder.GetCollection();
        foreach (var moveable in moveables)
        {
            moveable.StartMovement();
        }
    }

    private void OnDestroy()
    {
        _cts?.Dispose();
    }
}

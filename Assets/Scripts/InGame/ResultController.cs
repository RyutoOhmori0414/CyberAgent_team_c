using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    [SerializeField] private BoardRotater boardRotater;
    [SerializeField] private MoveObjectHolder moveObjectHolder;
    [SerializeField] private RotateCountView rotateCountView;
    [SerializeField] private Window stageClearWindow;
    [SerializeField] private Window failWindow;

    private int _remainedRotateCount;

    private IDisposable _playerDisposable;
    private IDisposable _targetDisposable;
    private CancellationTokenSource _cts;

    public void SetRotateCount(int count)
    {
        _remainedRotateCount = count;
    }

    private void Start()
    {
        _cts = new CancellationTokenSource();

        _playerDisposable = Player.OnDead
            .Subscribe(_ =>
            {
                OnPlayerDead();
            });
        
        _targetDisposable = Target.OnDead
            .Subscribe(_ =>
            {
                OnTargetDead();
            });
        
        boardRotater.OnRotate
            .Subscribe(_ =>
            {
                DecreaseRotateCount();
            }).AddTo(this);
    }

    private void DecreaseRotateCount()
    {
        _remainedRotateCount--;
        rotateCountView.SetCount(_remainedRotateCount);
        if (_remainedRotateCount <= 0)
        {
            WaitFinishAsync(_cts.Token).Forget();
        }
    }

    private async UniTaskVoid WaitFinishAsync(CancellationToken token)
    {
        var finishWaiter = new FinishWaiter(moveObjectHolder.GetCollection());
        await UniTask.WaitUntil(() => finishWaiter.IsFinished, cancellationToken: token);
        
        // 止まった or 時間が経過した
        _playerDisposable?.Dispose();
        _targetDisposable?.Dispose();
        OnFailed();
    }

    private void OnPlayerDead()
    {
        _playerDisposable?.Dispose();
        _targetDisposable?.Dispose();
        StopMovement();
        OnFailed();
    }

    private void OnTargetDead()
    {
        var targetCount = GetTargetCount();
        if (targetCount <= 0)
        {
            OnStageCleared();
        }
    }
    
    private void StopMovement()
    {
        var moveables = moveObjectHolder.GetCollection();
        foreach (var moveable in moveables)
        {
            moveable.StopMovement();
        }
    }

    private void OnStageCleared()
    {
        stageClearWindow.Open();
    }

    private void OnFailed()
    {
        failWindow.Open();
    }

    private void OnDestroy()
    {
        _cts?.Dispose();
    }

    private int GetTargetCount()
    {
        var moveables = moveObjectHolder.GetCollection();
        return moveables.Select(x => x is Target).Count();
    }

    private class FinishWaiter
    {
        public bool IsFinished { get; private set; }
        private ICollection<IMoveable> _moveables;
        private CancellationTokenSource _cts;

        public FinishWaiter(ICollection<IMoveable> moveables)
        {
            IsFinished = false;
            _moveables = moveables;   
            _cts = new CancellationTokenSource();
            WaitTime(_cts.Token).Forget();
            WaitAllVelocityStopped(_cts.Token).Forget();
        }

        private async UniTaskVoid WaitTime(CancellationToken token)
        {
            const float waitTime = 15f;
            await UniTask.Delay(TimeSpan.FromSeconds(waitTime), cancellationToken: token);
            IsFinished = true;
            _cts.Cancel();
        }

        private async UniTaskVoid WaitAllVelocityStopped(CancellationToken token)
        {
            const float minMagnitude = 0.5f;
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                if (_moveables.All(x => x.GetVelocity().magnitude <= minMagnitude))
                {
                    IsFinished = true;
                    _cts.Cancel();
                }

                if (token.IsCancellationRequested) return;
            }
        }
    }
}
using System;
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

    private static int _remainedRotateCount;

    private IDisposable _playerDisposable;
    private IDisposable _targetDisposable;
    private CancellationTokenSource _cts;

    public static void SetRotateCount(int count)
    {
        _remainedRotateCount = count;
    }

    private void Start()
    {
        _cts = new CancellationTokenSource();
        // TODO: PlayerとTargetのOnDeadを購読する
        boardRotater.OnRotate
            .Subscribe(_ =>
            {
                DecreaseRotateCount();
            }).AddTo(this);
    }

    private void DecreaseRotateCount()
    {
        _remainedRotateCount--;
        if (_remainedRotateCount <= 0)
        {
            WaitFinishAsync(_cts.Token).Forget();
        }
    }

    private async UniTaskVoid WaitFinishAsync(CancellationToken token)
    {
        // TODO: Player Targetの動きが止まるまで待つ or 時間経過を待つ処理を書く
    }

    private void OnPlayerDead()
    {
        StopMovement();
        OnFailed();
    }

    private void OnTargetDead()
    {
        // GetTargetCount();
        // TODO: 数みて条件一致ならクリア
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

    /*private int GetTargetCount()
    {
        var moveables = moveObjectHolder.GetCollection();
        return moveables.Select(x => x is Target).Count();
    }*/
}
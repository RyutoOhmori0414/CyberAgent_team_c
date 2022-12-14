using UnityEngine;

public interface IMoveable
{
    /// <summary>
    /// 移動を開始する
    /// </summary>
    public void StartMovement();

    /// <summary>
    /// 移動を止める
    /// </summary>
    public void StopMovement();

    /// <summary>
    /// オブジェクトのVelocityを取得する
    /// </summary>
    public Vector3 GetVelocity();
}
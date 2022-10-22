using UnityEngine;

public interface ITeleportable
{
    /// <summary>
    /// 行先にテレポートする
    /// </summary>
    /// <param name="transform">行先のTransform</param>
    public void TeleportTo(Transform transform);
}
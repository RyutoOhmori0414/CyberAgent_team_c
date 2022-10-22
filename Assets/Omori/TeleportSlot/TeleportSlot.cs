using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSlot : MonoBehaviour
{
    [Tooltip("プレイヤーがテレポートするTeleportSlot"), SerializeField]
    TeleportSlot _pairSlot;
    [Tooltip("このSlotと紐づけられたMuzzle"), SerializeField]
    Transform _muzzlePosition;
    public Transform MuzzlePosition
    {
        get { return _muzzlePosition; }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーかどうかを判断し、プレイヤーであればTeleportToを呼んでいる
        if(other.GetComponent<Player>())
        {
            other.GetComponent<Player>().TeleportTo(_pairSlot.MuzzlePosition);
        }
    }
}

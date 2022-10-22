using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSlot : MonoBehaviour
{
    [Tooltip("�v���C���[���e���|�[�g����TeleportSlot"), SerializeField]
    TeleportSlot _pairSlot;
    [Tooltip("����Slot�ƕR�Â���ꂽMuzzle"), SerializeField]
    Transform _muzzlePosition;
    public Transform MuzzlePosition
    {
        get { return _muzzlePosition; }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[���ǂ����𔻒f���A�v���C���[�ł����TeleportTo���Ă�ł���
        if(other.GetComponent<Player>())
        {
            other.GetComponent<Player>().TeleportTo(_pairSlot.MuzzlePosition);
        }
    }
}

using System;
using UnityEngine;

namespace Title
{
    public class TitleManager : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.instance.PlayBGM(0);
        }
    }
}
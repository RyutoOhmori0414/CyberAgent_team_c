using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioClip[] BGMList;
    [SerializeField] private AudioSource SE;
    [SerializeField] private AudioClip[] SEList;

    public static AudioManager instance;
    private const float BGMVolume = 0.3f;
    private const float SEVolume = 0.6f;

    private void Start()
    {
        // 簡易シングルトン
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayBGM(int index)
    {
        BGM.clip = BGMList[index];
        BGM.Play();
        BGM.volume = 0;
        BGM.DOFade(BGMVolume, 1f);
    }

    public void PlaySE(int index)
    {
        SE.PlayOneShot(SEList[index], SEVolume);
    }

    public void StopBGM()
    {
        BGM.Stop();
    }
    
    public void StopBGMWithFade(float fadeTime)
    {
        BGM.DOFade(0f, fadeTime).OnComplete(StopBGM).SetUpdate(true);
    }
    
    public void StopSE()
    {
        SE.Stop();
    }
}
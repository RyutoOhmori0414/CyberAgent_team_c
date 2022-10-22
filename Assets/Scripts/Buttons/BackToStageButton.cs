using UnityEngine;
using UnityEngine.EventSystems;

public class BackToStageButton : ButtonBase
{
    [SerializeField] private InGameProcessor inGameProcessor;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGM(0);
        inGameProcessor.GoBack();
    }
}
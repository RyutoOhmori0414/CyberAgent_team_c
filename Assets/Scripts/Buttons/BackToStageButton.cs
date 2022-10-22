using UnityEngine;
using UnityEngine.EventSystems;

public class BackToStageButton : ButtonBase
{
    [SerializeField] private InGameProcessor inGameProcessor;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        inGameProcessor.GoBack();
    }
}
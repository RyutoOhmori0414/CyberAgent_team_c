using UnityEngine;
using UnityEngine.EventSystems;

public class GoNextStageButton : ButtonBase
{
    [SerializeField] private InGameProcessor inGameProcessor;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        inGameProcessor.GoNextStage();
    }
}
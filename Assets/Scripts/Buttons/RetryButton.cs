using UnityEngine;
using UnityEngine.EventSystems;

public class RetryButton : ButtonBase
{
    [SerializeField] private InGameProcessor inGameProcessor;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        inGameProcessor.Retry();
    }
}
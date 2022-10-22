using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelectButton : ButtonBase
{
    [SerializeField] private int stage;
    [SerializeField] private SceneChanger sceneChanger;

    public override void OnPointerClick(PointerEventData eventData)
    {
        InGameProcessor.GoStage(stage);
        sceneChanger.LoadScene($"Stage{stage}");
    }
}
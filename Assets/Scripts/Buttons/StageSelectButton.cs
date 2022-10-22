using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelectButton : ButtonBase
{
    [SerializeField] private int stage;
    [SerializeField] private SceneChanger sceneChanger;

    public override void OnPointerClick(PointerEventData eventData)
    {
        InGameProcessor.GoStage(stage);
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGM(1);
        sceneChanger.LoadScene($"Stage{stage}");
    }
}
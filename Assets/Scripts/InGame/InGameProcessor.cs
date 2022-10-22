using System;
using UnityEngine;

public class InGameProcessor : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private ResultController resultController;
    [SerializeField] private SceneChanger sceneChanger;

    private static int _currentStage;

    private void Start()
    {
        resultController.SetRotateCount(stageData.stageList[_currentStage - 1].maxRotateCount);
    }

    /// <summary>
    /// これだけ別でSceneChangerを呼んであげる（あんまりよくないコード）
    /// </summary>
    /// <param name="stage"></param>
    public static void GoStage(int stage)
    {
        _currentStage = stage;
    }

    public void GoNextStage()
    {
        _currentStage++;
        sceneChanger.LoadScene($"Stage{_currentStage}");
    }

    public void Retry()
    {
        sceneChanger.LoadScene($"Stage{_currentStage}");
    }

    public void GoBack()
    {
        sceneChanger.LoadScene($"StageSelect");
    }
}
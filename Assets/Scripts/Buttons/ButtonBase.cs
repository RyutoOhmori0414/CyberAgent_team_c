using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// オブジェクトをクリックしたとき
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    /// <summary>
    /// オブジェクトにカーソルが入った時
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    /// <summary>
    /// オブジェクトからカーソルが出た時
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
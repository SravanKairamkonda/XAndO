using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler
{
    [SerializeField] public Canvas m_Canvas;

    private CanvasGroup m_canvasGroup;
    private RectTransform m_RectTransform;


    private void Awake()
    {
        m_RectTransform=GetComponent<RectTransform>();
        m_canvasGroup = GetComponent<CanvasGroup>();    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        m_canvasGroup.alpha = 0.6f;
        m_canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        m_RectTransform.anchoredPosition += eventData.delta/m_Canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        m_canvasGroup.alpha = 1f;
        m_canvasGroup.blocksRaycasts=true;
        //ItemSlotManager.OnEmptyItemSlotInfo?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}

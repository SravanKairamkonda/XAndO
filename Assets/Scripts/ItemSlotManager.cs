using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;

/// <summary>
/// I feel that there is too much of time is going with this and couldn't see any progress 
/// </summary>
public class ItemSlotManager : MonoBehaviour
{
    [SerializeField] private GameObject m_ItemSlot;
    [SerializeField] private Canvas m_Canvas;

    public delegate void OnEmptyItemSlot();
    public static OnEmptyItemSlot OnEmptyItemSlotInfo;

    private int m_SpawnCount;

    private RectTransform m_rectTransform;

    [Range(1, 4)]
    public float m_SizeOfBlock;

    private void Start()
    {
        SpawnXObject();
        m_rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnEnable()
    {
        DragNDrop.OnPlayerTurnEnd += SpawnXObject;
    }
    
    private void OnDisable()
    {
       DragNDrop.OnPlayerTurnEnd -= SpawnXObject; 
    }

    private void SpawnXObject()
    {
        GameObject temp = Instantiate(m_ItemSlot);
        RectTransform tempRectTransfrom = temp.GetComponent<RectTransform>();
        temp.GetComponent<DragNDrop>().m_Canvas = m_Canvas;
        temp.transform.gameObject.name = (++m_SpawnCount).ToString();

        temp.transform.SetParent(this.transform);
        temp.transform.localScale = Vector3.one * m_SizeOfBlock;
        tempRectTransfrom.localPosition = m_rectTransform.localPosition;
        
    }



}

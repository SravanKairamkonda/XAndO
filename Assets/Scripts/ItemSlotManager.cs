using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;

public class ItemSlotManager : MonoBehaviour
{
    [SerializeField] private GameObject m_ItemSlot;
    [SerializeField] private Canvas m_Canvas;

    public delegate void OnEmptyItemSlot();
    public static OnEmptyItemSlot OnEmptyItemSlotInfo;

    /// <summary>
    /// 
    /// </summary>
    private int m_SpawnCount;

    private void Start()
    {
        SpawnXObject();
    }

    public void OnEnable()
    {
        DragNDrop.OnPlayerTurnEnd += SpawnXObject;
    }
    
    private void OnDisable()
    {
       DragNDrop.OnPlayerTurnEnd -= SpawnXObject; 
    }

    /// <summary>
    /// 
    /// </summary>
    private void SpawnXObject()
    {
        GameObject temp = Instantiate(m_ItemSlot);
        RectTransform tempRectTransfrom = temp.GetComponent<RectTransform>();
        temp.GetComponent<DragNDrop>().m_Canvas = m_Canvas;
        temp.transform.gameObject.name = (++m_SpawnCount).ToString();

        temp.transform.SetParent(this.transform);
        temp.transform.localScale = Vector3.one * 1.5F;
        tempRectTransfrom.localPosition = this.transform.position;
        
    }



}

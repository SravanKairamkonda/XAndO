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

    private void SpawnXObject()
    {
        GameObject temp = Instantiate(m_ItemSlot);
        temp.transform.parent = transform;
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localScale = Vector3.one * 1.5f;
        temp.GetComponent<DragNDrop>().m_Canvas = m_Canvas;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_XItemSlot;
    [SerializeField] private GameObject m_OItemSlot;

    private bool whoseTurn;

    public delegate void OnChangeTurn();
    public static event OnChangeTurn onChangeTurnClicked;

   

    private void Awake()
    {
        if (onChangeTurnClicked != null)
        {
            onChangeTurnClicked();
        }

        m_XItemSlot.SetActive(false);
        m_OItemSlot.SetActive(false);
    }

    private void Start()
    {
        if (whoseTurn)
        {
            m_XItemSlot.SetActive(false);
            m_OItemSlot.SetActive(true);
        }
        else
        {
            m_XItemSlot.SetActive(true);
            m_OItemSlot.SetActive(false);
        }
       
    }

    private void OnEnable()
    {
        onChangeTurnClicked += ChangeTurn;
    }

    private void OnDisable()
    {
        onChangeTurnClicked -= ChangeTurn;
    }

    private void ChangeTurn()
    {
        Debug.Log("ChangeTurn :) ");
        if (whoseTurn)
        {
            m_XItemSlot.SetActive(false);
            m_OItemSlot.SetActive(true);
            whoseTurn = false;
        }
        else
        {
            m_XItemSlot.SetActive(true);
            m_OItemSlot.SetActive(false);
            whoseTurn=true;
        }
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardManager : MonoBehaviour
{
    private const char xValue = 'X';
    private const char oValue = 'O';

    [SerializeField] private Button[] gridOneButtons;
    [SerializeField] private Button[] gridTwoButtons;
    [SerializeField] private Button[] gridThreeButtons;

    void Start()
    {
        AddvaluesToGrid(xValue, gridOneButtons);
        AddvaluesToGrid (oValue, gridTwoButtons);
        AddvaluesToGrid(xValue,gridThreeButtons);
    }

    private void AddvaluesToGrid(char value, Button[] buttons)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = value.ToString();
        }
    }
}

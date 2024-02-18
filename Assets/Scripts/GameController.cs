using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject nodeButton;
    [SerializeField] private GameObject[] gameObjects;

    private const char xValue = 'X';
    private const char oValue = 'O';

    private string tempName;

    private void Start()
    {
        GenerateBoard();
        MatchThreeValue();
    }

    private void GenerateBoard()
    {
        int x = 0;
        int y = 0;
        int z = 0;

        for (int i = 0; i <3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject node = Instantiate(nodeButton);
                node.transform.SetParent(this.transform);
                Vector2 pos = new Vector2(x, y);
                node.GetComponent<RectTransform>().anchoredPosition = pos;
                node.GetComponentInChildren<Text>().text = xValue.ToString();
                x += 100;
            }

            y += 100;
            x = 0;
        }
    }

    private void MatchThreeValue()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            tempName=gameObjects[i].transform.GetComponent<Text>().text=xValue.ToString();
            Debug.Log(tempName);    
        }
    }
    
}

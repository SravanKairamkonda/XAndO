using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject nodeButton;

    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        int x = 0;
        int y = 0;

        for (int i = 0; i <3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject node = Instantiate(nodeButton);
                node.transform.SetParent(this.transform);
                Vector2 pos = new Vector2(x, y);
                node.GetComponent<RectTransform>().anchoredPosition = pos;
                x += 100;
            }

            y += 100;
            x = 0;
            
        }
    }
    
}

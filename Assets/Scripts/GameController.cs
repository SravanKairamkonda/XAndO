using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject nodeButton;
    [SerializeField] private List<GameObject> gameObjects;

    private const string xValue = "X";
    private const string oValue = "O";

    private Text tempName;

    private void Start()
    {
        GenerateBoard();
        Debug.Log(gameObjects.Count);
        MatchThreeValue();
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
                gameObjects.Add(node);  
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
        foreach (GameObject node in gameObjects) 
        {
            tempName=node.transform.GetComponentInChildren<Text>();

            if(tempName.text.ToString()==xValue)
            {
                tempName.text=oValue.ToString();
            }
           
            Debug.Log(tempName.text);
        }
    }
    
}

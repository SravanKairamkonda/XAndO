using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject nodeButton;
    [SerializeField] private List<GameObject> m_WhiteSpaces;

    private const string xValue = "X";
    private const string oValue = "O";

    private bool playerTurn;

    private Text tempName;

    private void Start()
    {
        GenerateBoard();
        //Debug.Log(gameObjects.Count);
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
                // Adding to button to a list 
                GameObject node = Instantiate(nodeButton);
                m_WhiteSpaces.Add(node);  
                node.transform.SetParent(this.transform);

                // Position of Button
                Vector2 pos = new Vector2(x, y);
                node.GetComponent<RectTransform>().anchoredPosition = pos;

                // Change Image event
                node.GetComponent<Button>().onClick.AddListener(() => ChangeImage(0));

                //node.GetComponentInChildren<Text>().text = xValue.ToString();
                
                x += 100;
            }

            y += 100;
            x = 0;
        }
    }

    private void MatchThreeValue()
    {
        foreach (GameObject node in m_WhiteSpaces) 
        {
            tempName=node.transform.GetComponentInChildren<Text>();

            if(tempName.text.ToString()==xValue)
            {
                tempName.text=oValue.ToString();
            }
           
            //Debug.Log(tempName.text);
        }
    }

    public void ChangeImage(int number)
    {
        m_WhiteSpaces[number].gameObject.GetComponentInChildren<Text>().text = xValue.ToString();
    }
    
}

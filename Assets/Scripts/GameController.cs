using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<TMP_Text> buttonList;
    private string playerSide;

    void Start () 
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceOnButtons () 
    {
        for (int i=0; i<buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide () 
    {
         return playerSide;
    }

    public void EndTurn () 
    { 
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) 
        {
            GameOver();
        }
    }

    void GameOver () 
    {
        for (int i=0; i<buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
}

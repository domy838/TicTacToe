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

    void SetGameControllerReferenceOnButtons() 
    {
        for (int i=0; i<buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide() 
    {
         return playerSide;
    }

    public void EndTurn() 
    { 
        for (int i=0; i<=8; i=i+3)
        {
            if(buttonList[i].text == playerSide && buttonList[i+1].text == playerSide && buttonList[i+2].text == playerSide)
            {
                GameOver();
            }
        }
        for (int i=0; i<3; i++)
        {
            if(buttonList[i].text == playerSide && buttonList[i+3].text == playerSide && buttonList[i+6].text == playerSide)
            {
                GameOver();
            }
        }
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) 
        {
            GameOver();
        }
        if (buttonList[6].text == playerSide && buttonList[4].text == playerSide && buttonList[2].text == playerSide) 
        {
            GameOver();
        }
        ChangeSides();
    }

    void GameOver() 
    {
        for (int i=0; i<buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    void ChangeSides() 
    {
        if(playerSide == "X")
        {
            playerSide = "O";
        }
        else
        {
            playerSide = "X";
        }
    }
}

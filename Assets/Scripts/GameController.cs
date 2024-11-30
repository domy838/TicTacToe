using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<TMP_Text> buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    private int moveCount;

    void Start () 
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
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
        moveCount++;
        if (moveCount >= 9) 
        { 
            SetGameOverText("It's a draw!");
        }
        ChangeSides();
    }

    void GameOver() 
    {
        SetBoardInteractable(false);
        SetGameOverText(playerSide + " Wins!");
        moveCount --;
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

    void SetGameOverText(string value) 
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame() 
    {
        playerSide = "X"; 
        moveCount = 0; 
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);
        for (int i=0; i<buttonList.Count; i++)
        {
            buttonList[i].text = ""; 
        }
    }
    void SetBoardInteractable (bool toggle); 
    {
        for (int i = 0; i < buttonList.Count; i++) 
        { 
            buttonList[i].GetComponentInParent<Button>().interactable = toggle; 
        }
    }
}

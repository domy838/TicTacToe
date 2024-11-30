using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<TMP_Text> buttonList;

    void Start () 
    {
         SetGameControllerReferenceOnButtons();
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
         return "?";
    }

    public void EndTurn () 
    { 
        Debug.Log("EndTurn is not implemented!"); 
    }
}

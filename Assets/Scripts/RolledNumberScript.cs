using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RolledNumberScript : MonoBehaviour
{
    public DiceRollScript diceRollScript;
    [SerializeField]
    Text rolledNmberText;

    public void Awake()
    {
        diceRollScript = FindObjectOfType<DiceRollScript>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (diceRollScript != null)
            if (diceRollScript.isLanded)
                rolledNmberText.text = diceRollScript.diceFaceNum;
            else
                rolledNmberText.text = "?";
        else
            Debug.LogError("DiceRollScript not foundin a scene!");
    }

    public int GetDiceNum()
    {
        int num = Convert.ToInt32(diceRollScript.diceFaceNum);
        //Debug.Log("GetDiceNum() returning: " + num);
        return num;
    }
}

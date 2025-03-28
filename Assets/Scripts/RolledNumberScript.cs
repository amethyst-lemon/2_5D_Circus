using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolledNumberScript : MonoBehaviour
{
    DiceRollScript diceRollScript;
    [SerializeField]
    Text rolledNmberText;

    void Awake()
    {
        diceRollScript = FindObjectOfType<DiceRollScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diceRollScript != null)
            if (diceRollScript.isLanded)
                rolledNmberText.text = diceRollScript.diceFaceNum;
            else
                rolledNmberText.text = "?";
        else
            Debug.LogError("DiceRollScript not foundin a scene!");
    }
}

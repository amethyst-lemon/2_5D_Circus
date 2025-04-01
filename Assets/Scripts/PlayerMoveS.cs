using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveS : MonoBehaviour
{
    //dice stuff
    public float moveDistance = 1.0f;
    public RolledNumberScript rolledNumberScript;
    public DiceRollScript diceRollScript;

    //movement route stuff
    public RouteScript currentRoute;
    int routePosition;
    public int steps = 0;
    bool isMoving;
    public int diceThrowCount;

    public void Awake()
    {
        rolledNumberScript = FindObjectOfType<RolledNumberScript>();
        currentRoute = FindAnyObjectByType<RouteScript>();
        diceRollScript = FindObjectOfType<DiceRollScript>();
    }

    private void Update()
    {
        if (diceRollScript.isLanded && !isMoving)
        {
            steps = rolledNumberScript.GetDiceNum();
            Debug.Log("1st " + steps);

            if (routePosition+steps < currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
            }

        } else if (!isMoving && Input.GetMouseButton(0))
            if(diceRollScript.isLanded)
                {
                steps = rolledNumberScript.GetDiceNum();
                Debug.Log("2nd " + steps);

                if (routePosition + steps < currentRoute.childNodeList.Count)
                    {
                        StartCoroutine(Move());
                    }
                } else
                {
                    Debug.Log("Dice lost");
            }
        
    }

    IEnumerator Move()
    {
        
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        
        steps = diceRollScript.GetFaceNum();
        //for(int i = steps; steps > 0; i--)
        while (steps > 0)
        {
            //steps here make a loop because the same value is called constantly
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
            Debug.Log("3rd "+steps);

        } if (steps == 0)
        {
           diceThrowCount++;
            yield break;
        }

            isMoving = false;
    }

    private bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }

}

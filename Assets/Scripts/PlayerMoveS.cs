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

    public PlayerScript playerScript;//

    public void Awake()
    {
        rolledNumberScript = FindObjectOfType<RolledNumberScript>();
        currentRoute = FindAnyObjectByType<RouteScript>();
        diceRollScript = FindObjectOfType<DiceRollScript>();
        playerScript = FindObjectOfType<PlayerScript>();

        StartCoroutine(EnsureRouteReady());
    }

    void Start()
    {
        StartCoroutine(EnsureRouteReady());
    }

    private void Update()
    {
        //Debug.Log("Update() - Dice Landed: " + diceRollScript.isLanded + " | Is Moving: " + isMoving + " | Steps: " + steps);

        if (diceRollScript.hasThrown && !diceRollScript.isLanded)
        {
            steps = 0;
        }

        if (diceRollScript.hasThrown && diceRollScript.isLanded)
        {
            steps = rolledNumberScript.GetDiceNum();
            //Debug.Log("Dice rolled, steps: " + steps);
            diceRollScript.hasThrown = false;
        }

        if (diceRollScript.isLanded && !isMoving && steps > 0)
        {
            StartCoroutine(Move());
        }
        
    }

    IEnumerator Move()
    {
        
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        
        while (steps > 0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;

            FindObjectOfType<PlayerScript>().AddScore(this.gameObject, 10);

            for (int i = routePosition; i <= routePosition + steps && i < currentRoute.childNodeList.Count; i++)
            {
                if (currentRoute.specialSpots.ContainsKey(i))
                {
                    string spotType = currentRoute.specialSpots[i];
                    //Debug.Log(gameObject.name + " checking spot at position: " + i + " - Type: " + spotType);

                    if (spotType == "Good" && steps == 0)
                    {
                        //Debug.Log(gameObject.name + " landed on a GOOD spot! +50 points.");
                        FindObjectOfType<PlayerScript>().AddScore(this.gameObject, 50);
                    }
                    else if (spotType == "Bad" && steps == 0)
                    {
                        //Debug.Log(gameObject.name + " landed on a BAD spot! -30 points.");
                        FindObjectOfType<PlayerScript>().AddScore(this.gameObject, -30);
                    }
                }
            }
        }

            isMoving = false;
            diceRollScript.isLanded = false;
            steps = 0;
            FindObjectOfType<PlayerScript>().EndTurn();
    }

    IEnumerator EnsureRouteReady()
    {
        while (currentRoute == null || currentRoute.specialSpots.Count == 0)
        {
            Debug.Log("Waiting for RouteScript to initialize...");
            yield return null;
        }
        Debug.Log("RouteScript initialized! Ready to check special spots.");
    }

    private bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }

}

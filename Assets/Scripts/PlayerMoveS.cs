using System.Collections;
using System.Collections.Generic;
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
            Debug.Log(steps);

            if (routePosition+steps < currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
                
            }
            else
            {
                Debug.Log("Rolled number too high!");
            }
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
        }

        isMoving = false;
    }

    private bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }

}

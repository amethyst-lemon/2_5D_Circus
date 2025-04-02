using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceRollScript : MonoBehaviour
{
    Rigidbody rBody;
    Vector3 position;
    [SerializeField]private float maxRandForceVal, startRollingForce;
    float forceX, forceY, forceZ;
    public string diceFaceNum;
    public string checkNum;
    public bool isLanded = false;
    public bool firstThrow = false;
    public bool hasThrown = false;

    void Awake()
    {
        Initialize(0);
    }

    public void Update()
    {
        if(rBody != null)
        {
            if(Input.GetMouseButton(0) && isLanded || Input.GetMouseButton(0) && !firstThrow)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit) )
                    if(hit.collider != null && hit.collider.gameObject == this.gameObject)
                    {
                        if (!firstThrow)
                            firstThrow = true;
                        
                        RollDice();
                        hasThrown = true;
                        isLanded = false;
                    }
            }
        }

        //if (isLanded && hasThrown)
        //{
        //    Debug.Log("Dice landed, waiting for next roll.");
        //}
    }

    public void Initialize(int node)
    {
        if (node == 0)
        {
            rBody = GetComponent<Rigidbody>();
            position = transform.position;

        } else if(node == 1)
            position = transform.position;

        firstThrow = false;
        isLanded = false;
        hasThrown = false;
        rBody.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }

    public void RollDice()
    {
        rBody.isKinematic = false;
        forceX = Random.Range(0, maxRandForceVal);
        forceY = Random.Range(0, maxRandForceVal);
        forceZ = Random.Range(0, maxRandForceVal);
        rBody.AddForce(Vector3.up * Random.Range(800, startRollingForce));
        rBody.AddTorque(forceX, forceY, forceZ);
    }

    public int GetFaceNum()
    {
        return Convert.ToInt32(diceFaceNum);
    }

    public void ResetDiceAfterLanding()
    {
        if (isLanded)
        {
            hasThrown = false;
        }
    }
}

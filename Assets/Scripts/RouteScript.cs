using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RouteScript : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();
    public Dictionary<int, string> specialSpots = new Dictionary<int, string>();

    void Awake()
    {
        Debug.Log("RouteScript is running!");
    }

    void Start()
    {
        Debug.Log("Forcing Special Spots Update!");
        FillNodes();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        FillNodes();

        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if(i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    private void FillNodes()
    {
        childNodeList.Clear();
        specialSpots.Clear();

        childObjects = GetComponentsInChildren<Transform>();

        int index = 0;
        foreach (Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);

                if (child.CompareTag("GoodSpot"))
                {
                    specialSpots[index] = "Good";
                    //Debug.Log("Good spot added at index: " + index);
                }
                else if (child.CompareTag("BadSpot"))
                {
                    specialSpots[index] = "Bad";
                    //Debug.Log("Bad spot added at index: " + index);
                }

                index++;
            }
        }

        //Debug.Log("Total special spots: " + specialSpots.Count);
    }
}

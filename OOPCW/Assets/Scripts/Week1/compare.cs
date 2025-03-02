using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compare : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    void Start()
    {
        CompareObjects();
    }

    void CompareObjects()
    {
        int object1ints = GetObjectInts(object1);
        int object2ints = GetObjectInts(object2);

        if (object1ints > object2ints)
        {
            Debug.Log("The sum of object 1 integers is greater than the sum of object 2 integers");
        }
        else if (object2ints > object1ints)
        {
            Debug.Log("The sum of object 1 integers is less than the sum of object 2 integers");
        }
        else
        {
            Debug.Log("The sum of object 1 integers is equal to the sum of object 2 integers");
        }
    }

    int GetObjectInts(GameObject obj)
    {
        wk1Script myScript = obj.GetComponent<wk1Script>();
        if (myScript != null)
        {
            return myScript.integer1 + myScript.integer2;
        }
        return 0;
    }
}
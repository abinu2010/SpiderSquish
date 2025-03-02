using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wk1Script : MonoBehaviour
{
    public bool comp = true;
    public int integer1 = 5;
    public int integer2 = 8;

    void Start()
    {
        if (comp)
        {
            CompareIntegers();
        }
    }

    void CompareIntegers()
    {
        if (integer1 > integer2)
        {
            Debug.Log("Integer 1 is > Integer 2");
        }
        else if (integer2 > integer1)
        {
            Debug.Log("Integer 2 is > Integer 1");
        }
        else
        {
            Debug.Log("They are equal");
        }
    }
}

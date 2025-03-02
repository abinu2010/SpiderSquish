using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetKey(bool keyBool)
    {
        hasKey = keyBool;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

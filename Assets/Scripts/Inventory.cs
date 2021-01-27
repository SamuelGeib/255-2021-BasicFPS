using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    
    // This is our Singleton Design Pattern
    private static Inventory _main;
    public static Inventory main
    {
        get { return _main;  }
        private set { _main = value; }
    }

    public bool hasKey = false;
    public bool hasSword = false;

    private void Start()
    {
        if (_main == null)
        {
            _main = this;
            DontDestroyOnLoad(gameObject);// Tells this object not to be destroyed when a level loads. 
        } else
        {
            Destroy(gameObject); // This will destroy the second inventory if it exists. 
        }
    }
}


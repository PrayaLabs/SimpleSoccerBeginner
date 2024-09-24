using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
   public int x;
    public GameObject y;
    // Start is called before the first frame update
    void Start()
    {
        x = 5;
        Debug.Log(y.gameObject.name); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

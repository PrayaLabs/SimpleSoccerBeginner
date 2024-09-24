using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos_change : MonoBehaviour
{
    public float x, y, z;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ball.GetComponent<Transform>().position = new Vector3(x,y,z);
    }
}

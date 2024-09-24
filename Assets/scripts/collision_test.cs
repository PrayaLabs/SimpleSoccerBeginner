using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");
        collision.gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_script : MonoBehaviour
{
    public GameObject Light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Light.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Light.SetActive(false);
    }
}

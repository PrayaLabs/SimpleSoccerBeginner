using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiate_demo : MonoBehaviour
{
    public GameObject myprefab;
    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame
  public void Test()
    {
        Instantiate(myprefab, new Vector3(Random.Range(-1, 1), 0, 0), Quaternion.identity);
    }
}

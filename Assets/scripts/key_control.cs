using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_control : MonoBehaviour
{
    float move_horizontal;
    float move_vertical;
    Rigidbody rb;
    public GameObject ball;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move_horizontal = Input.GetAxis("Horizontal");
        move_vertical = Input.GetAxis("Vertical");
        rb.AddForce(move_vertical*speed, 0, -move_horizontal*speed);
    }
}

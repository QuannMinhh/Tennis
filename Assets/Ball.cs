using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Vector3 initialPos;
    public bool hasExitedAimTarget = false;


    void Start()
    {
        Collider collider = GetComponent<Collider>();
        initialPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Net"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPos;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("aimTarget"))
        {
            hasExitedAimTarget = true;
        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}

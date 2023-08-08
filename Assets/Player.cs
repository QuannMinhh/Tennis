using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    float force = 13;


    bool hitting;

    Animator animator;

    ShotManager shotManager;
    Shot currentShot;

    private void Start()
    {
        shotManager = GetComponent<ShotManager>();
        currentShot = shotManager.topSpin;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // get the horizontal axis of the keyboard
        float v = Input.GetAxisRaw("Vertical"); // get the vertical axis of the keyboard

        if (Input.GetKeyDown(KeyCode.K))
        {
            hitting = true; // we are trying to hit the ball and aim where to make it land
            currentShot = shotManager.topSpin; // set our current shot to top spin
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            hitting = false; // we let go of the key so we are not hitting anymore and this 
        }                    // is used to alternate between moving the aim target and ourself

        



        if (hitting)  // if we are trying to hit the ball
        {
            aimTarget.Translate(new Vector3(h, 0, v) * speed * 2 * Time.deltaTime); //translate the aiming gameObject on the court horizontallly
        }


        if ((h != 0 || v != 0) && !hitting) // if we want to move and we are not hitting the ball
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); // move on the court
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
        }
    }
}


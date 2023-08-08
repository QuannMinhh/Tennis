using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bot : MonoBehaviour
{

    float speed = 4f; 
    public Transform ball;
    public Transform aimTarget; 

    public Transform[] targets; 

    float force = 13; 
    Vector3 targetPosition; 

    ShotManager shotManager; 


    
    void Start()
    {
        targetPosition = transform.position; 
       
        shotManager = GetComponent<ShotManager>(); 

    }

    
    void Update()
    {
        Move();
    }

  
     void Move()
    {
        targetPosition.x = ball.position.x; 
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
    }

    Vector3 PickTarget()
    {
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0);
            
        }
    }
}

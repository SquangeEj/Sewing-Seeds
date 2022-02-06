using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public GameObject player;
    // public Transform goal;
    public Vector3 StartPosition;
    public string tagtodetect;
    public string State;
    public NavMeshAgent agent;
    public Animator ballanimator;
    public bool playerseen = false;


    private void Start()
    {
        //ballanimator = GetComponent<Animator>();
        StartPosition = transform.position;
        player = GameObject.FindGameObjectWithTag(tagtodetect);
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        EnemyState();
    }

    void EnemyState()
    {
        switch (State)
        {

            case "Chase":

                //  player = GameObject.FindGameObjectWithTag(tagtodetect);

                agent.destination = player.gameObject.transform.position;

                break;

            case "Idle":
                // NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = StartPosition;
                break;
        }





    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
         
            //ballanimator.SetBool("FoundPlayer", true);
           


            State = "Chase";
            agent.stoppingDistance = 0f;
      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            State = "Idle";
            agent.stoppingDistance = 3f;
            
            //ballanimator.SetBool("FoundPlayer", false);
         
        }
    }

   

}
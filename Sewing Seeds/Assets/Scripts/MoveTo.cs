using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public GameObject player;
    // public Transform goal;
    public Vector3 PlantPosition;
    public Vector3 isitbackwards;
    public GameObject Plant;
    public float turnspeed;
    public string tagtodetect;
    public string State;
    public NavMeshAgent agent;
    public Animator animator;
    public bool playerseen = false;
    public float waittime = 0;
    public float startwaittime = 60;
    public float height;
    public float radius;
    public Renderer[] rends;
    public float randomhue,randomsat,randomval,randomalpha;



    private void Start()
    {
        randomhue = Random.Range(0.0f, 1.0f);
        randomsat = Random.Range(0.0f, 1.0f);
        randomval = Random.Range(0.0f, 1.0f);
        randomalpha = Random.Range(0.0f, 1.0f);
        // animator = GetComponent<Animator>();
        PlantPosition = Plant.transform.position;
        player = GameObject.FindGameObjectWithTag(tagtodetect);
        agent = GetComponent<NavMeshAgent>();
        foreach(Renderer rend in rends )
        {
            rend.material.color = Random.ColorHSV(randomhue, randomhue, randomsat, randomsat, randomval, randomval,randomalpha,randomalpha);
        }
        
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

                if (player != null)
                {
                    agent.destination = player.gameObject.transform.position;
                }
                if(player == null)
                {
                    player = GameObject.FindGameObjectWithTag(tagtodetect);
                }

                break;

            case "Idle":
                // NavMeshAgent agent = GetComponent<NavMeshAgent>();
                if (Plant != null)
                {
                    waittime -= 1;
                    Debug.Log("lmao");
                    if (waittime <= 0)
                    {
                        Vector3 randomDirection = Random.insideUnitSphere * radius;
                        randomDirection += PlantPosition;
                        NavMeshHit hit;
                        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
                        Vector3 finalPosition = hit.position;
                        Debug.Log("lol");
                        waittime = startwaittime;
                        agent.destination = finalPosition; //PlantPosition + new Vector3(Random.Range(-15f, 15f), height-3, Random.Range(-15f, 15f));
                    }
                }
                break;
        } 





    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yeah its colliding idiot " + tagtodetect);
        
        if (other.gameObject.CompareTag(tagtodetect))
        {
            Debug.Log("lol fucked");
         
            animator.SetBool("Chase", true);
           


            State = "Chase";
            agent.stoppingDistance = 0f;
      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag(tagtodetect))
        {
            State = "Idle";
            agent.stoppingDistance = 3f;
            
            animator.SetBool("Chase", false);
         
        }
    }

   

}
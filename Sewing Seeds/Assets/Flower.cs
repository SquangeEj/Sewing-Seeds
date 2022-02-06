using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flower : MonoBehaviour
{
    public GameObject spawnedthing;
    public GameObject spider;
    public Vector3 spawnheight;
    public Vector3 Scale, scalechange;
    public float growing = 0;
    public float maxgrow = 100;
    public float growspeed = 1;
    public float spiderspawn = 1800;
    

    

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        growspeed = ((growspeed * 1000) * Random.Range(0.1f, 1.5f));
        
        for (int i =0; i < 1; i++) 
          {
            Vector3 randomPosition = new Vector3(Random.Range(-10,10) * 2f, 0f, Random.Range(-10, 10)) + this.transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPosition, out hit, 100f, NavMesh.AllAreas)){
                GameObject instance = Instantiate(spawnedthing, hit.position + spawnheight , Quaternion.identity) as GameObject; //bloby is your prefab that you already created
                instance.GetComponent<MoveTo>().Plant = this.gameObject;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (growing < maxgrow)
        {
            growing += maxgrow /growspeed ; //lower growspeed = faster growing
            grow();
        }
        spiderspawn -= 1;
        if(spiderspawn <0)
        {
            spiderspawn = 1800;
            Vector3 randomPosition = new Vector3(Random.Range(-30, 30) * 2f, 0f, Random.Range(-30, 30)) + this.transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPosition, out hit, 100f, NavMesh.AllAreas))
            {
                GameObject instance = Instantiate(spider, hit.position + spawnheight, Quaternion.identity) as GameObject; //bloby is your prefab that you already created
                instance.GetComponent<MoveTo>().Plant = this.gameObject;
            }
        }
    }

    private void grow()
    {
        scalechange = new Vector3(0.0001f, 0.0001f, 0.0001f);
        gameObject.transform.localScale += scalechange;


    }
}

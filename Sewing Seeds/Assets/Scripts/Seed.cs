using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject flower;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Farm")
        {
            Instantiate(flower, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

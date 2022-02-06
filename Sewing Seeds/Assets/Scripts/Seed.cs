using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject flower;


 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Farm")
        {
            Instantiate(flower, transform.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
            Destroy(gameObject);
        }
    }
}

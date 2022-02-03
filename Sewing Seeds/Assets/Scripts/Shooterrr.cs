using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooterrr : MonoBehaviour
{
    public GameObject[] seed;
    public float shootforce= 5;
    public int currentflower = 0;



    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("yeah");
            var bulletspawned = Instantiate(seed[currentflower], transform.position, transform.rotation);
            bulletspawned.GetComponent<Rigidbody>().AddForce(shootforce * transform.forward, ForceMode.Impulse);
            if (shootforce >= 10)
            {
                shootforce -= 10f;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Swapped Seed");
            currentflower += 1;
        }

    }

  
   
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooterrr : MonoBehaviour
{
    public GameObject[] seedis;
    public GameObject[] seedes;
    public GameObject[] seedsn;
    public string currentarea = "Island";
    public float shootforce= 5;
    public int currentflower = 0;



 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("yeah");
            if (currentarea == "Island")
            {


                var seedisspawned = Instantiate(seedis[currentflower], transform.position, transform.rotation);
                seedisspawned.GetComponent<Rigidbody>().AddForce(shootforce * transform.forward, ForceMode.Impulse);
            }

            if (currentarea == "Desert")
            {
                var seedesspawned = Instantiate(seedes[currentflower], transform.position, transform.rotation);
                seedesspawned.GetComponent<Rigidbody>().AddForce(shootforce * transform.forward, ForceMode.Impulse);
            }
            if (currentarea == "Snow")
            {
                var seedsnspawned = Instantiate(seedsn[currentflower], transform.position, transform.rotation);
                seedsnspawned.GetComponent<Rigidbody>().AddForce(shootforce * transform.forward, ForceMode.Impulse);
            }



        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Swapped Seed");
            if (currentflower == 1)
            {
                currentflower = 0;
            }
            else currentflower = 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Island"))
        {
            currentarea = "Island";
            Debug.Log("Island");
        }
        if (other.tag == ("Snow"))
        {
            currentarea = "Snow";
            Debug.Log("Snow");
        }
        if (other.tag == ("Desert"))
        {
            currentarea = "Desert";
            Debug.Log("Desert");
        }
    }

}

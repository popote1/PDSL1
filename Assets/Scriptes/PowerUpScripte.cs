using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScripte : MonoBehaviour
{
    public int ShealdChargeValue =5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(("powerUpCollision"));
        if (other.transform.CompareTag("Player"))
        {
            GetComponent<ShealdScripte>().shealdChargeUp(ShealdChargeValue);
            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("sheald"))
        {
            other.gameObject.GetComponent<ShealdScripte>().shealdChargeUp(ShealdChargeValue);
            Destroy(gameObject);
        }
    }

   
}

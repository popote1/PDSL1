using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShealdScripte : MonoBehaviour
{

    public GameObject ShealdLoad;
    public GameObject Sheald;
    public float ShealdloadValue;
    public float ImpactCost;
    [HideInInspector]public float _shealdValue;

    private void Start()
    {
        _shealdValue = ShealdloadValue;
    }

    private void Update()
    {
        ShealdLoad.transform.localScale =new Vector3(
            Mathf.Lerp(ShealdLoad.transform.localScale.x, _shealdValue / ShealdloadValue, 0.5f),1,1);

      
    }

    private void ShealOFF()
    {
        Sheald.GetComponent<MeshRenderer>().enabled = false;
        Sheald.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void ShealdON()
    {
        Sheald.GetComponent<MeshRenderer>().enabled = true;
        Sheald.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void shealdChargeUp(int charge)
    {
        if (!Sheald.active)  ShealdON();
        _shealdValue = Mathf.Clamp(_shealdValue + charge, 0, ShealdloadValue);
    }

    public void ContacteSheal(GameObject bullet)
    {
        _shealdValue -= ImpactCost;
        if (_shealdValue < 0) _shealdValue = 0;
        if (_shealdValue == 0)
        {
            ShealOFF();
        }
        


        /*Debug.DrawLine(GetComponentInParent<Transform>().position,transform.up+GetComponentInParent<Transform>().position,Color.red, 0.5f);

         Vector2 velocity=bullet.GetComponent<Rigidbody2D>().velocity;
         Vector2 normal = GetComponentInParent<Transform>().position - transform.up +
                          GetComponentInParent<Transform>().position;
         float puissance = velocity.magnitude;
         bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

         float angle = (-(Vector2.SignedAngle(velocity, normal)))*Mathf.Deg2Rad;
         
         velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))*puissance*2;
         
        bullet.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
*/
    }
}

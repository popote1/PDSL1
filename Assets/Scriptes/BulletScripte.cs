using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScripte : MonoBehaviour
{
    public GameObject PSBulletEnd;
    private Transform lastPos;
    private bool shealded;
    void Start()
    {
        lastPos = transform;
        shealded = false;
    }
    void Update()
    {
        Vector2 _dir = (lastPos.position-transform.position);

        RaycastHit2D hit;
        if (Physics2D.Raycast(transform.position, _dir))
        {
            hit = Physics2D.Raycast(transform.position, _dir);
            Debug.Log("Sa Touche Quelque chose !!");
        }
        /*if (hit.collider != null)
        {
            Debug.Log("sa touche quelque chose");
            if (hit.collider.gameObject.transform.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }

        }*/

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject ps;
        if (other.transform.CompareTag("Wall"))
        {
            ps = Instantiate(PSBulletEnd, transform.position, Quaternion.identity);
            Destroy(ps,0.8f);
            Destroy(gameObject);
        }

        if (other.transform.CompareTag("sheald"))
        {
            other.gameObject.GetComponent<ShealdScripte>().ContacteSheal(gameObject);
            shealded = true;
        }

        if (other.transform.CompareTag("Ennemi"))
        {
            Destroy(other.transform.parent.gameObject);
            if (shealded)
            {
                Camera.main.GetComponent<GameManager>().EnnemieKillBounce();
            }
            else
            {
                Camera.main.GetComponent<GameManager>().EnnemieKillDirect();
            }
        }
        if (other.transform.CompareTag("Player"))
        {
            Camera.main.GetComponent<GameManager>().GameOver();
            ps = Instantiate(PSBulletEnd, transform.position, Quaternion.identity);
            Destroy(ps,0.8f);
            Destroy(gameObject);
        }
    }

    
}

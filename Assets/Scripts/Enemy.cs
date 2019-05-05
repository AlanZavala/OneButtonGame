using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private bool rightSide;
    public float speed;
    public bool checkCollision;
    public GameObject startP;
    public GameObject endP;

    void Start()
    {
        if (!rightSide)
        {
            transform.position = startP.transform.position;
        }
        else
        {
            transform.position = endP.transform.position;
        }
    }

    void Update()
    {
        if (!rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, endP.transform.position, speed * Time.deltaTime);
            if (transform.position == endP.transform.position)
            {
                rightSide = true;
                //GetComponent<SpriteRenderer>().flipX = true;
                transform.Rotate(0f, 180f, 0f);
            }

        }
        if (rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, startP.transform.position, speed * Time.deltaTime);
            if (transform.position == startP.transform.position)
            {
                rightSide = false;
                //GetComponent<SpriteRenderer>().flipX = false;
                transform.Rotate(0f, 180f, 0f);
                Debug.Log("asdas");
            }

        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(startP.transform.position, endP.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EspecialFloor")) { 
        
        }
    }
}

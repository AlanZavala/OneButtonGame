using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private bool rightSide;
    private float speed=3;
    public bool checkCollision=false;
    public GameObject startP;
    public GameObject endP;
    public int lives = 12;
    private int playerLives = 5;
    public Text scoreText;
    public Text instrusctions;
    public Text feedback;
    public Text playerLife;
    public GameObject panelText;

    public GameObject winPanel;

    void Start()
    {

        panelText.SetActive(false);
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

        if (playerLives<=0) {
            panelText.SetActive(true);
        }
        if (lives<=0) {
            winPanel.SetActive(true);
        }

        if (!rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, endP.transform.position, speed * Time.deltaTime);
            if (transform.position == endP.transform.position)
            {
                rightSide = true;

                transform.Rotate(0f, 180f, 0f);
            }

        }
        if (rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, startP.transform.position, speed * Time.deltaTime);
            if (transform.position == startP.transform.position)
            {
                rightSide = false;
             
                transform.Rotate(0f, 180f, 0f);

            }

        }
        if (Input.GetButtonDown("Jump") )
        {


            if (!checkCollision) {
                lives--;
                scoreText.text = "EnemyLife: "+lives.ToString("0");

                feedback.text = "You hit him";
                speed= (float)(speed + 0.5);
            }
            else {
                playerLives--;
                playerLife.text="Lives: "+playerLives.ToString("0");
            }
        }
    }
    //public void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(startP.transform.position, endP.transform.position);
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EspecialFloor"))
        {
            Debug.Log("Hola");
            checkCollision = true;
        }
        else
        {
            Debug.Log("Adios");
            checkCollision = false;
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EspecialFloor"))
        {
            Debug.Log("Hola");
            checkCollision = true;
            feedback.text = " ";
        }
        else if(collision.gameObject.CompareTag("Untagged")){
            Debug.Log("Adios");
            checkCollision = false;
        }
    }
    public void restart() { 
    
        
    }


}

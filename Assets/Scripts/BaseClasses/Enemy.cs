using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public List<GameObject> enemyPath;
    public List<GameObject> allEnemies;
    public GameObject decayCircle;
    public float health;
    public float speed;

    public GameObject EndCore;



    private int locationOnPath = 0;

    public Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        enemyPath = GameObject.Find("Path").GetComponent<PathList>().path;
       
        allEnemies = gameManager.enemies;

        EndCore = GameObject.Find("Core");

    }

    // Update is called once per frame
    void Update()
    {
        if (locationOnPath <= enemyPath.Count - 1)
        {
            //calculate move direction
            Vector2 moveDirection = (Vector2)enemyPath[locationOnPath].transform.position - (Vector2)transform.position;
            moveDirection.Normalize();
            moveDir = moveDirection;

            //update position
            transform.position = (Vector2)transform.position + (moveDirection * speed * Time.deltaTime);

            //if the enemy gets close enough to the point on the path, switch the location
            if (Vector2.Distance(transform.position, enemyPath[locationOnPath].transform.position) < 0.05f && locationOnPath <= enemyPath.Count - 1)
            {
                locationOnPath++;
            }
        }

        if(health == 0)
        {
            Die();
        }

        //conditional for when they get to the end of the map
        if(locationOnPath >= enemyPath.Count)
        {
            //kill the enemy after it does damage to the core
            gameManager.health--;

            //make sure the slider updates before it dies
            
            if (this.name == "SmallMushroom(Clone)")
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(1);
            }
            else if (this.name == "MediumMushroom(Clone)")
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(3);
            }
            else if (this.name == "LargeMushroom(Clone)")
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(5);
            }
            else
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(1);
            }
            
            Die();
        }
    }



    public void TakeDamage(float damage)
    {
        health = health - damage;

        if(health < 0)
        {
            health = 0;
        }

    }

    void Die()
    {
        //conditionals to determine gold amount received
        if (this.name == "SmallMushroom(Clone)")
        {
            gameManager.gold += 25;
        }
        else if (this.name == "MediumMushroom(Clone)")
        {
            gameManager.gold += 50;
        }
        else if (this.name == "LargeMushroom(Clone)")
        {
            gameManager.gold += 100;
        }
        else
        {
            EndCore.GetComponent<CoreScript>().TakeDamage(1);
        }


        GameObject dCircle = Instantiate(decayCircle);
        dCircle.transform.position = transform.position;
        gameManager.decayCircles.Add(dCircle);
        allEnemies.Remove(gameObject);
        Destroy(gameObject);
    }

}

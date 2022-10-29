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

    private int locationOnPath = 0;

    public Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        enemyPath = GameObject.Find("Path").GetComponent<PathList>().path;
       
        allEnemies = gameManager.enemies;

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
        GameObject dCircle = Instantiate(decayCircle);
        dCircle.transform.position = transform.position;
        gameManager.decayCircles.Add(dCircle);
        allEnemies.Remove(gameObject);
        Destroy(gameObject);
    }

}

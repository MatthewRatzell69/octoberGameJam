using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public List<GameObject> enemyPath;
    public List<GameObject> allEnemies;
    public GameObject decayCircle;
    private float health;
    public float startingHealth;
    public float speed;

    public float collisionRadius;

    public Slider slider;
    public float sliderLerpSpeed;

    public GameObject EndCore;

    private float originalXScale;

    private int locationOnPath = 0;

    public Vector3 moveDir;

    //need this to make sure we dont increase speed every frame and only do it once
    private int lastRound;




    // Start is called before the first frame update
    void Start()
    {
        enemyPath = GameObject.Find("Path").GetComponent<PathList>().path;
       
        allEnemies = gameManager.enemies;

        EndCore = GameObject.Find("Core");

        originalXScale = transform.localScale.x;

        slider.maxValue = startingHealth;
        health = startingHealth;

        lastRound = gameManager.roundNum -1;

    }

    // Update is called once per frame
    void Update()
    {

        if (lastRound < gameManager.roundNum)
        {
            //increase speeds of enemys based on the rounds
            speed = speed +.1f;
            //make sure we iterate the lastRound or its going to keep going
            lastRound = gameManager.roundNum;
        }

        
        //if they are not on the last path point
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

        SetHealthSlider(health, startingHealth);

        if(health == 0)
        {
            Die();
        }

        //conditional for when they get to the end of the map
        if(locationOnPath >= enemyPath.Count)
        {
           

            //make sure the slider updates before it dies
            
            if (this.name == "SmallMushroom(Clone)")
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(5);
            }
            else if (this.name == "MediumMushroom(Clone)")
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(10);
            }
            else if (this.name == "LargeMushroom(Clone)")
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(15);
            }
            else
            {
                EndCore.GetComponent<CoreScript>().TakeDamage(1);
            }
            
            Die();
        }

        //flip the sprite depending on what the moveDir.x value is
        if (moveDir.x >= 0)
        {
            transform.localScale = new Vector3(originalXScale * -1f, transform.localScale.y, transform.localScale.z);
           // Debug.Log("flipped");
        }

        if (moveDir.x < 0)
        {
            transform.localScale = new Vector3(originalXScale, transform.localScale.y, transform.localScale.z);
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
            gameManager.gold += 50;
        }
        else if (this.name == "MediumMushroom(Clone)")
        {
            gameManager.gold += 75;
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

    public void SetHealthSlider(float currentHealth, float maxHealth)
    {
        slider.value = Mathf.Lerp(slider.value, currentHealth, sliderLerpSpeed);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float towerMaxHealth;
    protected float towerHealth;
    public float attackCooldown;
    public float range;

    public Slider slider;
    public float sliderLerpSpeed;

    protected GameObject targetedEnemy;
    public float futureTargetPositionMultiplier;

    [SerializeField]
    private float decayMultiplier;

    protected List<GameObject> enemies;
    private List<GameObject> decayCircles;

    [SerializeField]
    private bool isTouchingDecayCircle;

    [SerializeField]
    private float timer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        towerHealth = towerMaxHealth;
        slider.maxValue = towerMaxHealth;
        slider.value = slider.maxValue;
        timer = attackCooldown;
        
        enemies = gameManager.enemies;
        decayCircles = gameManager.decayCircles;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer = timer - Time.deltaTime;
        isTouchingDecayCircle = false;

        for(int i = 0; i < enemies.Count; i++)
        {
            if(Vector2.Distance(enemies[i].transform.position, transform.position) < range && timer <= 0)
            {
                targetedEnemy = enemies[i];
                Attack();
                timer = attackCooldown;
            }
        }

        for(int i = 0; i < decayCircles.Count; i++)
        {

            float decayCircleRadius = decayCircles[i].GetComponent<DecayCircle>().damageRadius;

            if (Vector2.Distance(decayCircles[i].transform.position, transform.position) < decayCircleRadius)
            {
                isTouchingDecayCircle = true;
                decayMultiplier = decayCircles[i].GetComponent<DecayCircle>().decayMultiplier;
            }
        }

        //if there are no more decay circles, set the multiplier back to 1
        if(!isTouchingDecayCircle)
        {
            decayMultiplier = 1.0f;
        }

        towerHealth = towerHealth - (decayMultiplier * Time.deltaTime);

        //update the tower's slider
        SetHealthSlider(towerHealth, towerMaxHealth);

        //check if the Tower is alive
        if(towerHealth <= 0)
        {
            Die(0.05f);
        }

    }

    protected virtual void Attack()
    {
        Debug.Log("Tower has attacked!");
    }

    public void SetHealthSlider(float currentTowerHealth, float maxTowerHealth)
    {
        slider.value = Mathf.Lerp(slider.value, currentTowerHealth, sliderLerpSpeed);
    }

    private void Die(float delay)
    {
        Destroy(gameObject, delay);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Vector2 moveDirection;
    public List<GameObject> enemies;
    public float collisionRadius;
    public float speed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

        enemies = gameManager.enemies;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)transform.position + (moveDirection * Time.deltaTime * speed);

        //check for collision against the enemies
        for(int i = 0; i < enemies.Count; i++)
        {
            if (Vector2.Distance(transform.position, enemies[i].transform.position) < collisionRadius)
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

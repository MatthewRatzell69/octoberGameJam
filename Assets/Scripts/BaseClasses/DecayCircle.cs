using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayCircle : MonoBehaviour
{
    public float damageRadius;
    public float decayMultiplier;
    public float lifeTime;

    private float timer;

    private void Start()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        timer = timer - Time.deltaTime;

        if(timer <= 0)
        {
            gameManager.decayCircles.Remove(gameObject);
            Destroy(gameObject);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayCircle : MonoBehaviour
{
    public float damageRadius;
    public float decayMultiplier;
    public float lifeTime;

    private float timer;

    public ParticleSystem decayParticlesPrefab;
    ParticleSystem decayMushroomParticles;

    private void Start()
    {
        timer = lifeTime;
        decayMushroomParticles = Instantiate(decayParticlesPrefab);
        decayMushroomParticles.transform.position = transform.position;
    }

    private void Update()
    {
        timer = timer - Time.deltaTime;

        if(timer <= 0)
        {
            gameManager.decayCircles.Remove(gameObject);
            decayMushroomParticles.Stop();
            Destroy(gameObject);
        }

    }

}

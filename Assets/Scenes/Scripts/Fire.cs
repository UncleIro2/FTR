using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Flame")]
    [SerializeField, Range(0f, 1f)] private float currentIntersity = 1f;
    private float[] startIntensities = new float[0];
    [SerializeField] private ParticleSystem[] fireParticleSystems = new ParticleSystem[0];
    public bool isLit = true;

    [Header("Regen")]
    float timeLastWatered = 0f;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = 0.1f;


    private void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];

        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;

        }

    }

    private void Update()
    {
        if (isLit && currentIntersity < 1f && Time.time - timeLastWatered >= regenDelay)
        {
            currentIntersity += regenRate * Time.deltaTime;
            ChangeIntensity();


        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastWatered = Time.time;

        currentIntersity -= amount;

        ChangeIntensity();

        if (currentIntersity <= 0f)
        {
            Destroy(this.gameObject);
            return true;


        }

        //ild er stadig tændt
        return false;

    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {

            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntersity * startIntensities[i];

        }


    }
}

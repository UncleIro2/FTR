using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]  private float currentIntersity = 1f;
    
    private float [] startIntensities = new float [0];

    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

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
        ChangeIntensity();
    }

    private void ChangeIntensity () 
    {
        for (int i = 0;i < fireParticleSystems.Length;i++)
        {

            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntersity * startIntensities[i];

        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstParticles : MonoBehaviour
{
    new ParticleSystem particleSystem;

    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Emit(Color color)
    {
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(color);

        Emit();
    }

    public void Emit()
    {
        particleSystem.Play();

        LeanTween.delayedCall(3f, () => Destroy(gameObject));
    }
}

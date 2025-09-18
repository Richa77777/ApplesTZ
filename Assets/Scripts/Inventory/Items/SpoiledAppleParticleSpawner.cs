using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoiledAppleParticleSpawner : MonoBehaviour
{
    [SerializeField] ParticleSystemPool _particlePool;

    private void OnEnable()
    {
        EventHandler.OnAppleSpoiled += SetAndPlayParticle;
    }

    private void OnDisable()
    {
        EventHandler.OnAppleSpoiled -= SetAndPlayParticle;
    }

    private void SetAndPlayParticle(Apple apple)
    {
        if (!apple.InInventory)
        {
            ParticleSystem particle = _particlePool.GetItemFromPool();
            particle.gameObject.transform.position = apple.transform.position;
        }
    }
}
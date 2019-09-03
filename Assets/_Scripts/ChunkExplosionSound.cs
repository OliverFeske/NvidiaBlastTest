using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkExplosionSound : MonoBehaviour
{
    private ExplosionTest explosionTest;

    void Start()
    {
        explosionTest = GameObject.Find("ExplosionPoint").GetComponent<ExplosionTest>();
    }

    void OnCollisionEnter(Collision collision)
    {
        explosionTest.PlaySound();
    }
}

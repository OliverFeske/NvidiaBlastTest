using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
{
    [SerializeField] private Transform explosionPos;
    [SerializeField] private float explosionStrength = 20f;
    [SerializeField] private float explosionRadius = 2f;
    [SerializeField] private float upwardsMod = 3f;
    private Destructible[] destructibles;
    [SerializeField] private Rigidbody[] rbs;

    void Start()
    {
        destructibles = GetComponentsInChildren<Destructible>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < destructibles.Length; i++)
            {
                destructibles[i].GetForce();
            }
        }
    }

    public void AddExplosionForceToObject(GameObject _chunkPrefab)
    {
        rbs = _chunkPrefab.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].AddExplosionForce(explosionStrength, explosionPos.position, explosionRadius, upwardsMod);
        }
    }

    void OnDrawGizmos()
    {
        if (explosionPos == null) { return; }
        Gizmos.DrawWireSphere(explosionPos.position, explosionRadius);
        Gizmos.color = Color.red;
    }
}

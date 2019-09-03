using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Transform explosionPos;
    [Header("Variables")]
    [SerializeField] private float explosionStrength = 20f;
    [SerializeField] private float explosionRadius = 2f;
    [SerializeField] private float upwardsMod = 3f;
    [SerializeField] private float explosionTimer = 7f;

    private AudioSource source;
    private Destructible[] destructibles;
    private Rigidbody[] rbs;
    private bool canExplode = true;

    void Start()
    {
        destructibles = GetComponentsInChildren<Destructible>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canExplode)
        {
            destructibles = GetComponentsInChildren<Destructible>();
            StartCoroutine(DoExplosion());
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

    public void PlaySound()
    {
        source.PlayOneShot(explosionSound);
    }

    void OnDrawGizmos()
    {
        if (explosionPos == null) { return; }
        Gizmos.DrawWireSphere(explosionPos.position, explosionRadius);
        Gizmos.color = Color.red;
    }

    IEnumerator DoExplosion()
    {
        for (int i = 0; i < destructibles.Length; i++)
        {
            destructibles[i].GetForce();
        }

        explosionEffect.SetActive(true);
        source.PlayOneShot(explosionSound);
        canExplode = false;

        yield return new WaitForSeconds(7f);

        explosionEffect.SetActive(false);
        canExplode = true;
    }
}

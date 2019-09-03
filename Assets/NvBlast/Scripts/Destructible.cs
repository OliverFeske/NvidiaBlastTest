using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject fracturedPrefab;
    private ExplosionTest explosionTest;

    void Start()
    {
        explosionTest = transform.parent.GetComponent<ExplosionTest>();
    }

    //    private void OnMouseDown()
    //    {
    //        Instantiate(fracturedPrefab, transform.position, transform.rotation);
    //        Destroy(transform.root.gameObject);
    //    }

    public void GetForce()
    {
        GameObject chunkPrefab = (GameObject)Instantiate(fracturedPrefab, transform.position, transform.rotation);
        explosionTest.AddExplosionForceToObject(chunkPrefab);
        Destroy(gameObject);
    }
}

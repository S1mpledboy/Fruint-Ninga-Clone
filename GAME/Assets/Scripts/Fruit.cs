using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D fruitRigidbody;
    public GameObject slicedFruitPrefab;
    GameObject inst;
    Rigidbody[] rbsOnSliced;

    private void Awake()
    {
        fruitRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Blade") return;
        CreateSlicedFruit();
        GameManager.Instance.IncreeseScore(Random.Range(1,3));
    }
    private void OnEnable()
    {
        GameManager.OnGameRestart += DisableFruit;
        ObjectSpawner.AddImpulseToObject(fruitRigidbody);
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -5f) DisableFruit();
    }

    private void DisableFruit()
    {
       gameObject.SetActive(false);
       GameManager.OnGameRestart -= DisableFruit;
    }

    public void CreateSlicedFruit()
    {
        inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        DisableFruit();
        ApllyRandomExplosionForce();
    }
    private void ApllyRandomExplosionForce()
    {
        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(50, 100), transform.position, 5f);
        }
    }
}

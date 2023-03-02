using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    ObjectPooller objectPooller;
    string objectTag;

    private void Start()
    {
        objectPooller = ObjectPooller.objectPooller;
        StartCoroutine(SpawnFruits());
    }
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            objectPooller.SpawnFromPool(RandomizeTagOfSpawnedObject(), transform.position);
        }
        
    }
    private string RandomizeTagOfSpawnedObject()
    {
        int randomNumber = Random.Range(0, 100);
        if(randomNumber <= 25)
        {
            return objectTag = "Bomb";
        }else if(randomNumber>25&& randomNumber<=45)
        {
            return objectTag = "Orange";
        }
        else if (randomNumber > 45 && randomNumber <= 75)
        {
            return objectTag = "Banana";
        }else
        {
            return objectTag = "Watermelon";
        }
    }

    public static void AddImpulseToObject(Rigidbody2D objectRigidbody2D)
    {
        float xForce = Random.Range(-0.3f, 0.3f);
        float yForce = Random.Range(1f, 1.5f);
        Vector2 force = new Vector2(xForce, yForce);
        objectRigidbody2D.AddForce(force, ForceMode2D.Impulse);
    }
    

}

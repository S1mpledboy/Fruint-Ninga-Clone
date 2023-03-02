using UnityEngine;

public class BombScript : MonoBehaviour
{
    Rigidbody2D bombRigidbody;
    private void Awake()
    {
       bombRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Blade") return;
        GameManager.Instance.EndGame();
    }
    private void OnEnable()
    {
        GameManager.OnGameRestart += DisableBomb;
        ObjectSpawner.AddImpulseToObject(bombRigidbody);
    }
    private void DisableBomb()
    {
        gameObject.SetActive(false);
        GameManager.OnGameRestart -= DisableBomb;
    }
}

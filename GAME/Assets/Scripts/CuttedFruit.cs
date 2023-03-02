using UnityEngine;

public class CuttedFruit : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnGameRestart += DestroyCuttedFruit;
    }
    void Update()
    {
        if(transform.position.y < -5f)
        {
            DestroyCuttedFruit();
        }
    }
    private void OnDestroy()
    {
        GameManager.OnGameRestart -= DestroyCuttedFruit;
    }
    private void DestroyCuttedFruit()
    {
        Destroy(gameObject);
    }
}

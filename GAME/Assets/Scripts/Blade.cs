using UnityEngine;

public class Blade : MonoBehaviour
{
    Rigidbody2D bladeRigidbody2D;

    void Awake()
    {
        bladeRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetBladePositionToMousePosition();
    }
    void SetBladePositionToMousePosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 9;
        bladeRigidbody2D.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
  
}

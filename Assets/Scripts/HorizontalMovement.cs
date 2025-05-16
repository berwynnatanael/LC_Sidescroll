using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    static float t = 0.0f;
    [Header("Movement Settings")]
    public float distance, speed;
    private float originalPos;

    void Start()
    {
        originalPos = transform.position.x;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        t += Time.deltaTime * speed;    
        var x = originalPos + Mathf.Sin(t) * distance;
        transform.position = new Vector2(x, transform.position.y);
    }
}

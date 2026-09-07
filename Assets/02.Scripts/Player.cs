using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 1f;
    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(h, v);
        
        transform.Translate(_speed * Time.deltaTime * direction);
    }
}

using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    private Vector3 _direction;
    
    public Vector3 Direction { get => _direction; set => _direction = value; }
    
    // Start is called before the first frame update
    void Awake()
    {
        Direction = Vector3.up;
    }

    private void Update()
    {
        Move();
    }

    // Update is called once per frame
    void Move()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);

        if (_direction == Vector3.up && transform.position.y > 9.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            
            Destroy(gameObject);
        }
        else
        {
            if (transform.position.y < -5.0f) 
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }
                
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _direction == Vector3.down)
        {
            other.GetComponent<Player>().Damage();
        }
    }
}

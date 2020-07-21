using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (transform.position.y >= -5.6f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);
        }
        else
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
        }
    }
}

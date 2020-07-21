using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    
    [SerializeField]
    private GameObject _laserPrefab;

    private float _delay = 0.5f;

    private float _fireTime = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _fireTime)
        {
            
            Fire();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _speed);
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 0), 0);

        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        } 
    }

    void Fire()
    {
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        _fireTime = Time.time + _delay;
    }
}

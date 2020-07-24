using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] 
    private float _speed;
    [SerializeField]
    private GameObject _explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

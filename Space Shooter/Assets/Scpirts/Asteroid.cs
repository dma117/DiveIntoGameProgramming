using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] 
    private float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _speed));
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _screenWidth = 5;
    private float _screenHeight = 3;
    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _speed);

        if (Math.Abs(transform.position.y) >= _screenHeight)
        {
            transform.position = new Vector3(transform.position.x, _screenHeight * Mathf.Sign(transform.position.y), transform.position.z);
        }
        if (Math.Abs(transform.position.x) >= _screenWidth)
        {
            transform.position = new Vector3(_screenWidth * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
        }
    }
}

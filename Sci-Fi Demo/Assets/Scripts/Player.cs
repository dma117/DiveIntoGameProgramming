using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        var direction = new Vector3(horizontalInput, 0, verticalInput);
        var velocity = direction * _speed;
        velocity.y -= _gravity;
        
        velocity = transform.TransformDirection(velocity);
        

        _characterController.Move(velocity * Time.deltaTime);
    }
}

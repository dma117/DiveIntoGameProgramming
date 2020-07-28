using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;
    private float _yVelocity;

    private int _countCoins = 0;
    private int _lives = 3;

    public int CountCoins => _countCoins;
    public int Lives => _lives;

    private bool _isJumping;
    
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

        if (transform.position.y <= -6.0f)
        {
            UpdateLifes();
        }
    }

    void Move()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontalAxis, 0, 0);
        var velocity = direction * _speed;
        
        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _isJumping = true;
            }
            else
            {
                _isJumping = false;
            }
        }
        else
        {
            if (_isJumping && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _isJumping = false;
            }
            else
            {
                _yVelocity -= _gravity;
            }
        }

        velocity.y = _yVelocity;
        
        _characterController.Move(velocity * Time.deltaTime);
    }

    void UpdateLifes()
    {
        _lives--;
        transform.position = new Vector3(-0.27f, 5.04f, 0);
        
        if (_lives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateCoins()
    {
        _countCoins++;
    }
}

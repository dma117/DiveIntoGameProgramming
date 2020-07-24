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
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private int _lifes = 3;
    [SerializeField] 
    private int _score;
    [SerializeField]
    private AudioClip _shotSound;
    [SerializeField]
    private AudioClip _explosionSound;

    private AudioSource _audioSource;
    private GameObject _rightEngine;
    private GameObject _leftEngine;
    
    private SpawnManager _spawnManager;
    private UIManager _ui;
    
    private float _delay = 0.12f;
    private float _fireTime = 0.5f;
    private float _powerupTime = 5.0f;

    private bool _tripleShot;
    private bool _shieldPower;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _rightEngine = transform.Find("RightEngine").gameObject;
        _leftEngine = transform.Find("LeftEngine").gameObject;
        _audioSource = GetComponent<AudioSource>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
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
        _audioSource.clip = _shotSound;
        _audioSource.Play();
        
        if (_tripleShot)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
        
        _fireTime = Time.time + _delay;
    }

    public void Damage()
    {
        if (_shieldPower)
        {
            _shieldPower = false;
            _shieldVisualizer.SetActive(false);
        }
        else
        {
            _audioSource.clip = _explosionSound;
            _audioSource.Play();
            
            _lifes -= 1;

            if (_lifes == 2)
            {
                _rightEngine.SetActive(true);
            }

            if (_lifes == 1)
            {
                _leftEngine.SetActive(true);
            }

            _ui.UpdateLives(_lifes);

            if (_lifes < 1)
            {
                _spawnManager.OnPlayerDeath();
                
                _rightEngine.SetActive(false);
                _leftEngine.SetActive(false);
                
                Destroy(gameObject);
                _ui.GameOver();
            }
        }
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        _ui.SetScore(_score);
    }

    public void TripleShotActive()
    {
        _tripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(_powerupTime);
        _tripleShot = false;
    }

    public void SpeedShotActive()
    {
        _speed *= 1.5f;
        StartCoroutine(SpeedPowerUpRoutine());
    }

    IEnumerator SpeedPowerUpRoutine()
    {
        yield return new WaitForSeconds(_powerupTime);
        _speed /= 1.5f;
    }

    public void ShieldPowerActive()
    {
        _shieldPower = true;
        _shieldVisualizer.SetActive(true);
        StartCoroutine(ShieldPowerRoutine());
    }

    IEnumerator ShieldPowerRoutine()
    {
        yield return new WaitForSeconds(_powerupTime);
        _shieldPower = false;
        _shieldVisualizer.SetActive(false);
    }
}

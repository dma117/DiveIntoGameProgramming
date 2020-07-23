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
    
    private SpawnManager _spawnManager;
    private UIManager _ui;
    private float _delay = 0.12f;

    private float _fireTime = 0.5f;

    private bool _tripleShot;
    private bool _shieldPower;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();

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
            _lifes -= 1;
            _ui.UpdateLives(_lifes);

            if (_lifes < 1)
            {
                _spawnManager.OnPlayerDeath();
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
        yield return new WaitForSeconds(5.0f);
        _tripleShot = false;
    }

    public void SpeedShotActive()
    {
        _speed *= 1.5f;
        StartCoroutine(SpeedPowerUpRoutine());
    }

    IEnumerator SpeedPowerUpRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= 1.5f;
    }

    public void ShieldPowerActive()
    {
        _shieldPower = true;
        _shieldVisualizer.SetActive(true);
    }
}

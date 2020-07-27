using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 4.0f;
    [SerializeField]
    private AudioClip _explosionSound;
    [SerializeField]
    private GameObject _enemyFirePrefab;
    
    private AudioSource _audioSource;

    private Animator _enemyAnim;

    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _enemyAnim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(EnemyFireRoutine());
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser" && other.GetComponent<Laser>().Direction == Vector3.up)
        {
            _audioSource.clip = _explosionSound;
            _audioSource.Play();
            
            _enemyAnim.SetTrigger("OnEnemyDestroyed");
            
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
            Destroy(other.gameObject);
            _player.IncreaseScore(10);
        }
        else if (other.tag == "Player")
        {
            _audioSource.clip = _explosionSound;
            _audioSource.Play();
            
            _enemyAnim.SetTrigger("OnEnemyDestroyed");
            
            Destroy(GetComponent<Collider2D>());
            
            if (_player != null)
            {
                _player.Damage();
            }
            
            Destroy(gameObject, 2.8f);
        }
    }

    IEnumerator EnemyFireRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 8));
        
            var enemyFire = Instantiate(_enemyFirePrefab, transform.position, Quaternion.identity);
            var lasers = enemyFire.GetComponentsInChildren<Laser>();
        
            lasers[0].Direction = Vector3.down;
            lasers[1].Direction = Vector3.down;
        }
    }
}

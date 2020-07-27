using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] 
    private float _speed;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _spawnManager;
    [SerializeField]
    private AudioClip _explosionSound;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _explosionSound;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(GetComponent<Collider2D>());
            _audioSource.Play();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _spawnManager.GetComponent<SpawnManager>().StartSpawning();
            Destroy(gameObject, 1.1f);
        }
    }
}

using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private int _id;
    [SerializeField]
    private AudioClip _powerupSound;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _powerupSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -5.6f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            _audioSource.Play();
            
            var player = other.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                switch (_id)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedShotActive();
                        break;
                    case 2: 
                        player.ShieldPowerActive();
                        break;
                }
            }
            
            Destroy(gameObject, 0.2f);
        }
    }
}

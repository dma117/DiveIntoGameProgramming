using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private GameObject _weapon;

    private CharacterController _characterController;

    private int _countCoins;

    public int CountCoins { get => _countCoins; set => _countCoins = value; }
    
    // Start is called before the first frame update
    void Start()
    {
        _weapon.SetActive(false);
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

    public void UpdateCoins()
    {
        _countCoins++;
    }

    public void SetWeapon()
    {
        _weapon.SetActive(true);
        _weapon.GetComponent<Weapon>().SetAmmo();
    }
}

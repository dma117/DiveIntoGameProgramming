using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;

    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _coin;
    [SerializeField] private Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _ammoText.gameObject.SetActive(true);
        _coin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoin();
        ShowAmmo();
    }

    void ShowAmmo()
    {
        _ammoText.text = "Ammo: " + _weapon.GetComponent<Weapon>().CountAmmo;
    }
    
    private void ShowCoin()
    {
        _coin.SetActive(_player.CountCoins > 0);
    }
}

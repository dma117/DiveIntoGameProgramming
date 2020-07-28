using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private GameObject _player;
    public void UpdateCoins()
    {
        _coinsText.text = "Coins: " + _player.GetComponent<Player>().CountCoins;
    }
}

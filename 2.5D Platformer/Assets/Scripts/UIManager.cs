using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Text _lifesText;

    private void Update()
    {
        _coinsText.text = "Coins: " + _player.GetComponent<Player>().CountCoins;
        _lifesText.text = "Lives:" + _player.GetComponent<Player>().Lives;
    }
}

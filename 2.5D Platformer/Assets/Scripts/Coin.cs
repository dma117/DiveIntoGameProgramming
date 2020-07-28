using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private GameObject _ui;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().UpdateCoins();
            _ui.GetComponent<UIManager>().UpdateCoins();
            Destroy(gameObject);
        }
    }
}

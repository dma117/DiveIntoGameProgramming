using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().UpdateCoins();
            Debug.Log("HERE");
            Destroy(gameObject);
        }
    }
}

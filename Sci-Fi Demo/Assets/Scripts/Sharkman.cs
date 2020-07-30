using UnityEngine;

public class Sharkman : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            
            if (Input.GetKeyDown(KeyCode.E) && player.CountCoins > 0)
            {
                AudioSource.PlayClipAtPoint(_audioClip, transform.position);
                player.CountCoins--;
                player.SetWeapon();
            }
        }
    }
}

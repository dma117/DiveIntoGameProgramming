using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject _crateCracked;

    public void Destruct()
    {
        gameObject.SetActive(false);
        _crateCracked.SetActive(true);
        Destroy(gameObject);
    }
}

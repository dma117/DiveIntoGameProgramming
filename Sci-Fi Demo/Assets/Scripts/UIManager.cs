using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;

    [SerializeField] private GameObject _weapon;
    // Start is called before the first frame update
    void Start()
    {
        _ammoText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        _ammoText.text = "Ammo: " + _weapon.GetComponent<Weapon>().CountAmmo;
    }
}

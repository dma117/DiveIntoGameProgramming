using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private GameObject _hitMarker;
    [SerializeField] private AudioClip _audioClip;
    
    private AudioSource _audioSource;

    private int _currentAmmo;
    private int _maxAmmo = 50;

    private bool _isReloading;
    
    public int CountAmmo => _currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !_isReloading && _currentAmmo > 0)
        {
            _currentAmmo--;
            Hit();
        }
        else
        {
            _muzzleFlash.gameObject.SetActive(false);
            
            if (_audioSource.isPlaying)
            {
                StartCoroutine(AudioStopRoutine());
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R) && !_isReloading)
        {
            StartCoroutine(ReloadAmmunitionRoutine());
        }
    }

    void Hit()
    {
        _muzzleFlash.gameObject.SetActive(true);
            
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        if (Physics.Raycast(ray, out hitInfo))
        {
            var hit = Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            
            if (hitInfo.transform.tag == "Crate")
            {
                hitInfo.transform.GetComponent<Destructable>().Destruct();
            }
            
            Destroy(hit, 0.5f);
        }
    }

    IEnumerator AudioStopRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _audioSource.Stop();
    }

    IEnumerator ReloadAmmunitionRoutine()
    {
        _isReloading = true; 
        yield return new WaitForSeconds(1.5f);
        _isReloading = false;
        _currentAmmo = _maxAmmo;
    }

    public void SetAmmo()
    {
        _currentAmmo = _maxAmmo;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float _time = 5.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            var newEnemy =  Instantiate(_enemyPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 7, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_time);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

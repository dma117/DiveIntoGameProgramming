using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;

    public bool singleGame;

    void Start()
    {
        if (singleGame)
        {
            Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdateScene()
    {
       SceneManager.LoadScene(1); //current scene
    }
}

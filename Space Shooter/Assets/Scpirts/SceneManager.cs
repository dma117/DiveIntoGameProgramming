using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityManager = UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScene()
    {
       UnityManager.SceneManager.LoadScene(0);
    }
}

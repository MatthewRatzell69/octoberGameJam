using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlsBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("ExperimentScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ExperimentScene");
    }
}

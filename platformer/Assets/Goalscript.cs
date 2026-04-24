using System.Runtime.CompilerServices;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    public string level = "";

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        SceneManager.LoadScene(level);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

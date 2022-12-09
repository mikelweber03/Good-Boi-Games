using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Scene newGameScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        //SceneManager.LoadScene("MikelPrototyp");
        SceneManager.LoadScene("LucianosWorkSpace");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");   
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public void FirstScene()
    {
        SceneManager.LoadScene("colors_Level");
    }

    public void SecondScene()
    {
        SceneManager.LoadScene("Letters_Level");
    }

    public void ThirdScene()
    {
        SceneManager.LoadScene("Shapes_Level");
    }
}

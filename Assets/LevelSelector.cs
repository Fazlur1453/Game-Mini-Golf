using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
  

  

    public void Level1Begin()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2Begin()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3Begin()
    {
        SceneManager.LoadScene(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
  
    public void Level1ButtonClicked()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Level2ButtonClicked()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Level3ButtonClicked()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void Level4ButtonClicked()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void Level5ButtonClicked()
    {
        SceneManager.LoadScene("Level 5");
    }
   
}

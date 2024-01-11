using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class c : MonoBehaviour
{
    // Start is called before the first frame update
   public void NewGame()
    {
        
        SceneManager.LoadScene("MainScene");
    }
         public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    } 
   public void QuitGame()
{
    // save any game data here

        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;

}
}

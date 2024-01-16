using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class c : MonoBehaviour
{
    
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
    
        
        
        UnityEditor.EditorApplication.isPlaying = false;
}
}

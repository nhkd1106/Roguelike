using UnityEngine.SceneManagement;
using UnityEngine;

public class c : MonoBehaviour
{
    // Start is called before the first frame update
   public void NewGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Đóng scene hiện tại và xóa khỏi bộ nhớ
        SceneManager.UnloadSceneAsync(currentIndex);
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
   public void Exit()
    {
         Application.Quit(0);
    }
        
    
}

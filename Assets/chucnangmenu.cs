using UnityEngine.SceneManagement;
using UnityEngine;

public class c : MonoBehaviour
{
    // Start is called before the first frame update
   public void choimoi()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
   public void thoat()
    {
         Application.Quit(0);
    }
        
    
}

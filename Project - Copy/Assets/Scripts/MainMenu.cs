using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void CursorVisibility()
    {
        Cursor.visible = true;
    }
        public void PlayGame() 
        {
            SceneManager.LoadScene(6);
        }
        public void QuitGame()
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
}

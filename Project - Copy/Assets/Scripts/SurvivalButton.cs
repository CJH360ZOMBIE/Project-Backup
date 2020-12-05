using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SurvivalButton : MonoBehaviour
{
        public void PlayGame() 
        {
            SceneManager.LoadScene("Survival");
        }

           
        }
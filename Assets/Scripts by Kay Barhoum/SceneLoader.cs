
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KayBarhoum
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private LevellingSystem levellingSystem;
        private bool Next = false;

        void Update()
        {       // Next level will be opened and will tell you this.
            if (levellingSystem.levelNext == true)
            {
                Debug.Log("Next Level Opened");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }


        }
        // When the levelNext is true from Levelling Systems and you collide with the "flag" you can progress to next level.
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (levellingSystem.levelNext == true && collision.CompareTag("Flag"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            // Quits the game once you collide with it.
            if (collision.CompareTag("Terminate"))
            {
                Application.Quit();
                Debug.Log("Quit");
            }
            // Resets the game back to the start when you collide with it.
            if (collision.CompareTag("Again"))
            {
                SceneManager.LoadScene("Platformer (Basic Scene)");
                Debug.Log("Retry");
            }

        }


    }

}

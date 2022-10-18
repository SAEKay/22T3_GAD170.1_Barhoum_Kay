using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KayBarhoum
{

    public class LevellingSystem : MonoBehaviour
    {
        private int coins;
        public bool levelNext = false;
        [SerializeField] private SimpleCharacterController jumper; // links to the simple character controller script.

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == ("PowerJump"))
            { // power box that gives you more jumping power.
                jumper.jumpSpeed = (20); // This increases the power of your jumping speed by 20 points.
                Debug.Log("Increased Jump");
                Destroy(collision.gameObject); // this will destroy the game object when you collide with it.
            }

            if (collision.tag == ("Coin"))
            {
                coins += 1; // adds plus 1 point for each "coin" you come into contact with
                Debug.Log("Total Coins " + coins);
            }
        }

        private void Update()
        {
            if (coins == 3)
            { // if the coins equal to 3 in total then it will activate the levelNext for the scene loader.
                levelNext = true;
            }
        }


    }
}
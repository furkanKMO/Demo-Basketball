using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnManager : MonoBehaviour
{
    public GameObject Ball;
    public static bool respawn1 = false;
    public static int maxBall = 5, currentBall = 5, score = 0, scoreMultipler = 1, basketCount = 0;
    public Text scoreText, multiplerText, ballText;

    // Start is called before the first frame update
    void Start()
    {

        generalManager.isThrown = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score "+score.ToString();
        multiplerText.text ="Multipler "+ scoreMultipler.ToString();
        ballText.text ="Balls "+ maxBall + "/" + currentBall;
        if (respawn1)
        {
           
            generalManager.isThrown = false;
            generalManager.desiredForce = Vector3.zero;
            Instantiate(Ball, new Vector3(0, -0.8f, 0), Quaternion.identity);
            respawn1 = false;
        }
    }
}

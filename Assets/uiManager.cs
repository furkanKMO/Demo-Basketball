using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public static bool inMenu = true, lose = false, win = false;
    public GameObject startPanel,losePanel,WinPanel,starpanel1,starpanel2,fakeBall,starHolder;
    public RawImage s1, s2, s3;
    public Text wiScore, loScore;
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        starHolder.SetActive(false);
        inMenu = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lose)
        {
            starHolder.SetActive(false);
            losePanel.SetActive(true);
            if (respawnManager.basketCount==1||respawnManager.basketCount == 0)
            {
                starpanel1.SetActive(true);
                starpanel2.SetActive(false);
            }if(respawnManager.basketCount == 2)
            {
                starpanel1.SetActive(false);
                starpanel2.SetActive(true);
            }
            loScore.text = "Score = "+respawnManager.score.ToString();
        }
        if (win)
        {
            starHolder.SetActive(false);
            WinPanel.SetActive(true);
            wiScore.text = "Score = " + respawnManager.score.ToString();
        }
        if (respawnManager.basketCount==1)
        {
            s1.color = Color.white;
        }
        if (respawnManager.basketCount == 2)
        {
            s2.color = Color.white;
        }
        if (respawnManager.basketCount == 3)
        {
            s3.color = Color.white;
        }
    }
    public void Starbutton() 
    {
        starHolder.SetActive(true);
        s1.color = Color.black;
        s2.color = Color.black;
        s3.color = Color.black;
        fakeBall.SetActive(false);
        inMenu = false;
        lose = false;
        win = false;
        WinPanel.SetActive(false);
        losePanel.SetActive(false);
        respawnManager.currentBall = 5;
        respawnManager.scoreMultipler = 1;
        respawnManager.score = 0;
        respawnManager.basketCount = 0;
        respawnManager.respawn1 = true;
        startPanel.SetActive(false);
    
    
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TMP_Text board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        board.text = "Score: " + score.ToString();
    }
    public void addScore(int a){
        score+=a;
    }
}

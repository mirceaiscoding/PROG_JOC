using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int GetScore(){
        return this.score;
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}

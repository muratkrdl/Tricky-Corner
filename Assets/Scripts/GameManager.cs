using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace { get; private set; }

    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    ScoreSpawner scoreSpawner;

    void Awake() 
    {
        if(Instace == null)
        {
            Instace = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scoreText.text = score.ToString();
    }

    void Start() 
    {
        scoreSpawner = FindObjectOfType<ScoreSpawner>();
        scoreSpawner.SpawnScoree();    
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreSpawner.SpawnScoree();
    }

}

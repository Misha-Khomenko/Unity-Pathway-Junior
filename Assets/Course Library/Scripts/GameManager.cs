using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TMP_Text scoreText;
    private int score;
    private float timeLeft = 60.0f;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    private float spawnRate = 1.0f;
    
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
    }

   
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}

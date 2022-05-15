using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private bool restart;
    private bool gameOver;

    void Start()
    {
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        updateScore();
       StartCoroutine (spawner());
        
    }

    [System.Obsolete]
    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }


        }
    }
    IEnumerator spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "press R to restart";
                restart = true;
                break;
            }

        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void AddScore()
    {
        score += 10;
        updateScore();
    }
    void updateScore()
    {
        scoreText.text = "Score: " + score ;

    }
}

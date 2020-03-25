using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    // config parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f ;
    [SerializeField] int scorePerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    // State variables
    [SerializeField] int score = 0;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
         }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }



    // Update is called once per frame
    private void Start()
    {
        scoreText.text = score.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void addToScore()
    {
        score += scorePerBlock;
        scoreText.text = score.ToString();
    }
    public void DestroyYourself()
    {
        Destroy(gameObject);
    }

}

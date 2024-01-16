using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Completed;
using UnityEngine.UI;        
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public float levelStartDelay = 2f;
    
    public float turnDelay = 0.1f;
    
    public int playerFoodPoints = 100;
    
    public static GameManager instance = null;
    
    [HideInInspector] public bool playersTurn = true;
    
    private BoardManager boardScript;
    
    
    private Text levelText;
    
    private GameObject levelImage;
    private int level = 1;
    
    private List<Enemy> enemies;
    
    private bool enemiesMoving;
    
    private bool doingSetup = true;
    private GameObject GameOverScreen;
    
    void Awake()
    {
        
        if (instance == null)
            
            instance = this;
        
        else if (instance != this)
            
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
        
        enemies = new List<Enemy>();
        
        boardScript = GetComponent<BoardManager>();
        
        
    }
    
    void OnLevelWasLoaded(int index)
    {
        
        if (index==0){
        level++;
        }
        
        
        InitGame();
    }
    
    void InitGame()
    {
        
        doingSetup = true;
        
        levelImage = GameObject.Find("LevelImage");
        
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Day " + (level - 1);
        
        levelImage.SetActive(true);
        GameOverScreen = GameObject.Find("GameOverScreen");
        GameOverScreen.SetActive(false);
        
        Invoke("HideLevelImage", levelStartDelay);
        
        enemies.Clear();
        
        boardScript.SetupScene(level);
    }
    
    void HideLevelImage()
    {
        
        levelImage.SetActive(false);
        
        doingSetup = false;
    }
    
    void Update()
    {
        
        if (playersTurn || enemiesMoving || doingSetup)
            
            return;
        
        StartCoroutine(MoveEnemies());
    }
    
    public void AddEnemyToList(Enemy script)
    {
        
        enemies.Add(script);
    }
    
    public void GameOver()
    {
        
        levelText.text = "After " + (level - 1) + " days, you starved.";
        
        levelImage.SetActive(true);
        level = 1;
        doingSetup = true;
        
        Invoke("EnableGameOver", 2f);
        
        
    }
    private void EnableGameOver()
    {
        GameOverScreen.SetActive(true);
    }
    
    IEnumerator MoveEnemies()
    {
        
        enemiesMoving = true;
        
        yield return new WaitForSeconds(turnDelay);
        
        if (enemies.Count == 0)
        {
            
            yield return new WaitForSeconds(turnDelay);
        }
        
        for (int i = 0; i < enemies.Count; i++)
        {
            
            enemies[i].MoveEnemy();
            
            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        
        playersTurn = true;
        
        enemiesMoving = false;
    }
}

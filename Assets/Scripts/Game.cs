using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public int WaveIndex { get; private set; }
    public Wave CurrentWave { get; private set; }
    public bool CanSpawnEnemies;

    bool gameOver;

    [SerializeField] Sound gameOverSound;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] UI_WaveCounter waveCounter;
    [SerializeField] UI_GameOverDisplay gameOverDisplay;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if (gameOver && Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void NextWave()
    {
        WaveIndex++;

        waveCounter.UpdateWave(WaveIndex, this);
    }

    public void OnWaveStart()
    {
        CurrentWave = new Wave(WaveIndex, this);
    }

    public void OnPlayerDie()
    {
        gameOverSound.Play();

        Destroy(Player.Instance.gameObject);
        Destroy(enemySpawner);
        foreach (Enemy enemy in FindObjectsOfType<Enemy>()) {
            Destroy(enemy.gameObject);
        }

        gameOverDisplay.Show();
        gameOver = true;
    }
}

public class Wave
{
    Game game;
    int numEnemiesToSpawn;
    int numEnemiesToKill;

    public Wave(int index, Game game)
    {
        this.game = game;

        int numEnemies = (int)(Mathf.Pow(2f, index / 10f) * 10f);
        numEnemiesToSpawn = numEnemies;
        numEnemiesToKill = numEnemies;

        game.CanSpawnEnemies = true;
    }

    public void OnEnemySpawn()
    {
        numEnemiesToSpawn--;

        if (numEnemiesToSpawn <= 0)
        {
            game.CanSpawnEnemies = false;
        }
    }

    public void OnEnemyKill()
    {
        numEnemiesToKill--;

        if (numEnemiesToKill <= 0)
        {
            game.NextWave();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    bool leaveGameOnNextEscapePress;

    [SerializeField] GameSettings settings;
    [SerializeField] Sound gameOverSound;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] UI_WaveCounter waveCounter;
    [SerializeField] UI_EnemyCounter enemyCounter;
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

        CurrentWave = new Wave(WaveIndex, this, enemyCounter);
        waveCounter.UpdateWave(CurrentWave, this);
    }

    public void OnWaveStart()
    {
        CurrentWave = new Wave(WaveIndex, this, enemyCounter);
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

    public GameSettings Settings => settings;
}

public class Wave
{
    public int Index { get; private set; }
    public bool HordeWave { get; private set; }

    Game game;
    UI_EnemyCounter enemyCounter;
    int numEnemiesToSpawn;
    int numEnemiesToKill;

    public Wave(int index, Game game, UI_EnemyCounter enemyCounter)
    {
        Index = index;
        HordeWave = index.ToString().Last() == '5';
        this.game = game;
        this.enemyCounter = enemyCounter;

        int numEnemies = Mathf.FloorToInt(Mathf.Pow(2f, index / 5f) * 10f) * (HordeWave ? 2 : 1);
        numEnemiesToSpawn = numEnemies;
        numEnemiesToKill = numEnemies;
        enemyCounter.UpdateEnemyCount(numEnemies);
    }

    public void Start()
    {
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
        enemyCounter.UpdateEnemyCount(numEnemiesToKill);

        if (numEnemiesToKill <= 0)
        {
            game.NextWave();
        }
    }

    public void OnEnemyHitPlayer()
    {
        numEnemiesToSpawn++;

        game.CanSpawnEnemies = true;
    }
}

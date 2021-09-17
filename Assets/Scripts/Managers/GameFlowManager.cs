using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }

    public event Action OnGameStarted;
    public event Action OnGameEnded;

    [SerializeField] CounterScript counterScript;

    private bool isGameStarted;
    private bool isGameEnded;
    
    void Awake() {
        Instance = this;
    }

    IEnumerator Start() {
        LifeManager.Instance.OnLivesEnded += OnLivesEnded;
        EnemyCounterManager.Instance.OnAllEnemiesDestroyed += OnAllEnemiesDestroyed;
        yield return counterScript.GameStartTimer(5);
        isGameStarted = true;
        OnGameStarted?.Invoke();
    }

    private void OnAllEnemiesDestroyed() {
        EndGame();
    }

    private void OnLivesEnded() {
        EndGame();
    }

    private void EndGame() {
        OnGameEnded?.Invoke();
        isGameEnded = true;
    }

    private void Update() {
        if (!isGameEnded)
            return;
        if (Input.GetKeyDown (KeyCode.Space) || Input.touchCount > 0)
            SceneManager.LoadScene ("main");
    }

    public bool IsGameStarted() {
        return isGameStarted;
    }

    public bool IsGameEnded() {
        return isGameEnded;
    }
}

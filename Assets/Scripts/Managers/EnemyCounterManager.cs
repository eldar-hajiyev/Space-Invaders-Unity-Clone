using System;
using UnityEngine;

public class EnemyCounterManager : MonoBehaviour
{
    public static EnemyCounterManager Instance { get; private set; }

    public event Action OnAllEnemiesDestroyed;
    public event Action<int> OnEnemyCountChanged;
    
    private int enemyCounter;
    
    private void Awake() {
        Instance = this;
        EnemyScript[] enemyScripts = FindObjectsOfType<EnemyScript>();

        enemyCounter = enemyScripts.Length;

        foreach (EnemyScript enemyScript in enemyScripts)
            enemyScript.gameObject.AddComponent<DestroyEventBehaviour>().OnDestroyEvent += OnEnemyDestroyed;
    }

    void OnEnemyDestroyed()
    {
        if (this == null)
            return;
        enemyCounter--;
        OnEnemyCountChanged?.Invoke(enemyCounter);
        if (enemyCounter == 0)
            OnAllEnemiesDestroyed?.Invoke();
    }

    public int GetEnemyCount() {
        return enemyCounter;
    }
}
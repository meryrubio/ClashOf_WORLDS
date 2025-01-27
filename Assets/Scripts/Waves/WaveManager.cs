using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WaveManager : MonoBehaviour
{
    [Tooltip("Reference to the ObjectPooler script")]
    public Pool objectPooler;
    public int currentWave = 0; // Contador de oleadas
    private int baseEnemiesPerWave = 5; // Enemigos base por la primera oleada
    private int activeEnemies = 0; // Cuenta de enemigos activos


    private void Start()
    {
        StartWave();    
    }

    // M�todo para iniciar una nueva oleada
    public void StartWave()
    {
        int enemiesToSpawn = baseEnemiesPerWave + (currentWave) * 5; // Aumento de 5 enemigos por oleada

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = objectPooler.GimmeInactiveGameObject();
            if (enemy != null)
            {
                enemy.SetActive(true);
                activeEnemies++; // Incrementa el contador de enemigos activos
                //Enemy enemyBehaviour = enemy.GetComponent<Enemy>();
                //if (enemyBehaviour != null)
                //{
                //    enemyBehaviour.onDeath += OnEnemyDeath; // Suscribe el evento de muerte del enemigo
                //    // ES POSIBLE QUE EL EVENTO SE DUPLIQUE Y CASDA VEZ QUE AVANCEMOS DE RONDA, LA MUERTE DEL ENEMIGO CUENTE X2, X3,...
                //}
            }
            else
            {
                Debug.LogWarning("No more enemies available in pool. Consider increasing pool size or allowing expansion.");
                break;
            }
        }
        currentWave++;
    }

    // M�todo que se ejecuta cuando un enemigo muere
    private void OnEnemyDeath()
    {
        activeEnemies--;
        if (activeEnemies == 0) // Si no quedan enemigos activos
        {
            StartWave(); // Inicia la siguiente oleada
        }
    }
}

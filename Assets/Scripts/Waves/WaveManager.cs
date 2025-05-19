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
    public void SpawnEnemies(int enemyCount)
    {
        StartCoroutine(SpawnEnemiesOverTime(enemyCount));
    }
    // Método para iniciar una nueva oleada
    public void StartWave()
    {
        //OnEnemyDeath();
        int enemiesToSpawn = baseEnemiesPerWave + (currentWave) * 5; // Aumento de 5 enemigos por oleada
        SpawnEnemies(enemiesToSpawn); 
        activeEnemies = enemiesToSpawn;
        currentWave++;
    }

    // Método que se ejecuta cuando un enemigo muere
    private void OnEnemyDeath()
    {
        activeEnemies--;
        if (activeEnemies == 0) // Si no quedan enemigos activos
        {
            StartWave(); // Inicia la siguiente oleada
        }
    }


    private IEnumerator SpawnEnemiesOverTime(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = objectPooler.GimmeInactiveGameObject();
            if (enemy != null)
            {
                enemy.SetActive(true);
                enemy.transform.position = transform.position;
                enemy.GetComponent<EnemyTypeReference>().enemyType = new Enemy(2, GetComponent<Rigidbody>(), 10, 100);  

                // Incrementa el contador de enemigos activos
                Enemy enemyBehaviour = enemy.GetComponent<EnemyTypeReference>().enemyType;
                if (enemyBehaviour != null)
                {
                    enemyBehaviour.onDeath += OnEnemyDeath; // Suscribe el evento de muerte del enemigo
                    // ES POSIBLE QUE EL EVENTO SE DUPLIQUE Y CASDA VEZ QUE AVANCEMOS DE RONDA, LA MUERTE DEL ENEMIGO CUENTE X2, X3,...
                }
            }
            else
            {
                Debug.LogWarning("No more enemies available in pool. Consider increasing pool size or allowing expansion.");
                break;
            }
            yield return new WaitForSeconds(.3f);
        }
    }
    
}

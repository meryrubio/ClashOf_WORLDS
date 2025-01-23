using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WaveSpawner : MonoBehaviour
{
    
    public Pool objectPooler;
    
    public WaveManager waveManager;

    // M�todo para spawnear enemigos basado en la cantidad dada
    public void SpawnEnemies(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = objectPooler.GimmeInactiveGameObject();
            if (enemy != null)
            {
                enemy.SetActive(true);
                PositionEnemy(enemy);
                // Aqu� podr�as a�adir l�gica adicional para el enemigo, como configurar su salud, etc.
            }
            else
            {
                Debug.LogWarning("No more enemies available in pool. Consider increasing pool size or allowing expansion.");
                break;
            }
        }
    }

    // M�todo para posicionar el enemigo en el escenario (esto es muy b�sico)
    private void PositionEnemy(GameObject enemy)
    {
        // Ejemplo muy b�sico de posicionamiento, ajusta seg�n tu juego
        enemy.transform.position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
    }
}


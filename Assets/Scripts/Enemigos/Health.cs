using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
    public float maxHealth = 100f; // Salud máxima
    public float currentHealth; // Salud actual

    public float healthRegenAmount = 5f; // Cantidad de salud a regenerar
    public float regenInterval = 5f; // Intervalo de tiempo para regenerar salud
    private float lastDamageTime; // Tiempo del último daño recibido

    void Start()
    {

        currentHealth = maxHealth; // Inicializa la salud actual
        lastDamageTime = Time.time; // Inicializa el tiempo del último daño
                                    //InvokeRepeating("RegenerateHealth", regenInterval, regenInterval); // Llama a la función de regeneración en intervalos

    }

    public void TakeDamage(float amount)
    { // Solo el jugador local puede recibir daño

        currentHealth -= amount; // Reduce la salud actual
        if (currentHealth < 0) currentHealth = 0; // Asegúrate de que no sea negativa

        lastDamageTime = Time.time; // Actualiza el tiempo del último daño

        // Llama a la función para actualizar la barra de salud
        //UpdateHealthUI();

        // Si la salud llega a 0, el jugador muere
        if (currentHealth <= 0)
        {
            Die();
        }
    }



    // Método que se llama cuando el jugador muere
      void  Die()
    {
      Destroy(gameObject);
    }

   
}

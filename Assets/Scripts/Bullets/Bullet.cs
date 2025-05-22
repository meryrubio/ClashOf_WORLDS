using ClashofWorlds;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace ClashofWorlds
{  //crea un espacio de nombres para evitar la colision de nombres
    public class Bullet : MonoBehaviour
    {
        public float speed = 5;
        public Vector3 dir;
        private Rigidbody rb;
        private float currentTime = 0;
        
        public AudioClip shootClip; //audio de disparo
        
        // Start is called before the first frame update
        void Start()
        {

           rb = GetComponent<Rigidbody>();
            AudioManager.instance.PlayAudio(shootClip, "shootSound");

        }

        // Update is called once per frame
        void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 3)
            {
                currentTime = 0;
                speed = 0;

            }
            
        }

        private void FixedUpdate()
        {

            rb.velocity = dir * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyTypeReference type = other.GetComponent<EnemyTypeReference>();
            if (type)
            {
                CharacterManager cm = FindObjectOfType<CharacterManager>();
                type.enemyType.health -= cm.character.damage;
                gameObject.SetActive(false);
                type.enemyType.Death(type.gameObject);
                if (type.enemyType.health <= 0)
                {
                    if (Random.value <= 0.25f)
                    {
                        // 1) Elegir random el enum
                        var allTypes = (powerupEnum[])System.Enum.GetValues(typeof(powerupEnum));
                        powerupEnum chosen = allTypes[Random.Range(0, allTypes.Length)];

                        // 2) Cargar prefab genérico desde Resources/Powerup/PowerupBehaviourPrefab
                        GameObject prefab = Resources.Load<GameObject>("Powerup/PowerupBehaviourPrefab");
                        if (prefab == null)
                        {
                            Debug.LogError("No encuentro Resources/Powerup/PowerupBehaviourPrefab");
                        }
                        else
                        {
                            // 3) Instanciarlo en la posición del enemigo
                            GameObject pu = Instantiate(prefab, transform.position, Quaternion.identity);

                            // 4) Asignar el tipo para que en Start() el script monte mesh y lógica
                            var pb = pu.GetComponent<powerupBehaviour>();
                            if (pb != null)
                                pb.powerupType = chosen;
                        }

                    }
                }
            }
        }

    }
}

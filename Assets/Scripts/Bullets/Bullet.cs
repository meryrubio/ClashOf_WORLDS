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
        Character character, enemy;
        // Start is called before the first frame update
        void Start()
        {

           rb = GetComponent<Rigidbody>();
           character = GetComponent<Character>();
           enemy = GetComponent<Enemy>();
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
            if (!other.GetComponent<Player_movement>())
            {
                enemy.health -= character.damage;
                gameObject.SetActive(false);
                
            }
        }

    }
}

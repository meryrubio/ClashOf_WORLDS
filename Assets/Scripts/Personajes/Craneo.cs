using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClashofWorlds
{
    public class Craneo : PlayableCharacter
    {
        public GameObject gameOverPanel;
        public Craneo(float speed, Rigidbody rb) : base(speed, rb, Resources.Load<GameObject>("Craneo"), 10, 200, 0.1f)
        {
        }

        public override void Attack(GameObject owner)
        {
            BulletSpawn(owner.transform, owner.GetComponentInChildren<BulletPool>().bulletPool);

        }

        void BulletSpawn(Transform transform, Pool bulletPool)
        {
            GameObject obj = bulletPool.GimmeInactiveGameObject();
            if (obj)
            {
                obj.SetActive(true);

                obj.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 1, transform.transform.position.z) + transform.forward * 2;
                obj.GetComponent<Bullet>().dir = transform.forward;
                obj.GetComponent<Bullet>().speed = 5;

            }
        }
    
    public override void Death(GameObject owner)
        {
            if (health <= 0)
            {
               GameManager.instance.GameOver();
               owner.SetActive(false);
               gameOverPanel.SetActive(true);
               //GameManager.instance

            }
        }
    }
}
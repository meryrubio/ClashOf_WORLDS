using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public Pool bulletPool;
    public PoolType poolTypeToSearch;

    


    private void Start()
    {

        PoolType typeToSearch = PoolType.BULLET_CRANEO;

        switch (GameManager.instance.characterType)
        {
            case Characters.CRANEO:
                typeToSearch = PoolType.BULLET_CRANEO;
                break;
            case Characters.GHOSTFACE:
                typeToSearch = PoolType.BULLET_GHOSTFACE;
                break;
            case Characters.PANTERA:
                typeToSearch = PoolType.BULLET_PANTERA;
                break;
        }

        Pool[] allPools = FindObjectsOfType<Pool>();
        foreach (Pool pool in allPools)
        {
            if (pool.poolType == typeToSearch)
            {
                bulletPool = pool;
                break;
            }
        }
        //Pool[] pools = FindObjectsOfType<Pool>();

        //foreach (Pool pool in pools)
        //{
        //    if (pool.poolType == poolTypeToSearch)  
        //    {
        //        bulletPool = pool;
        //        break;
        //    }
        //}


    }
}

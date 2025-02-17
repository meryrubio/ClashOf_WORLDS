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
        Pool[] pools = FindObjectsOfType<Pool>();

        foreach (Pool pool in pools)
        {
            if (pool.poolType == poolTypeToSearch)  
            {
                bulletPool = pool;
                break;
            }
        }


    }
}

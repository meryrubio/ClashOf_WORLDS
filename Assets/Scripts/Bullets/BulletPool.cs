using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public Pool bulletPool;
    public PoolType poolTypeToSearch;

    //public enum PoolType
    //{
    //    CraneoBullet,
    //    GhostFaceBullet,
    //    PanteraBullet
    //}


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

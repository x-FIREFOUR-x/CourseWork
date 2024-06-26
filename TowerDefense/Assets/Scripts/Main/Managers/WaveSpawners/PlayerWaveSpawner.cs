﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TowerDefense.Main.Enemies;
using TowerDefense.Main.UI.EnemyMenu;


namespace TowerDefense.Main.Managers.WaveSpawners
{
    public class PlayerWaveSpawner : WaveSpawner
    {
        [SerializeField]
        private EnemyShopMenu enemyShopMenu;

        public override void Initialize(Transform spawn)
        {
            base.Initialize(spawn);

            availableEnemy = new List<EnemyType>();
            availablePrices = new Dictionary<EnemyType, int>();
        }

        void Update()
        {
            if (!WaveFinished())
            {
                return;
            }
            else
            {
                if (AllCurrentWaveEnemiesSpawned)
                {
                    OperationAfterFinishWave();
                    AllCurrentWaveEnemiesSpawned = false;
                }
            }

            if (timeToNextSpawn <= 0f)
            {
                StartCoroutine(SpawnWave());
                timeToNextSpawn = timeBetweenWaves;
            }
            timeToNextSpawn -= Time.deltaTime;
            timeToNextSpawn = Mathf.Clamp(timeToNextSpawn, 0f, Mathf.Infinity);
        }

        private IEnumerator SpawnWave()
        {
            nextWave = enemyShopMenu.TakeEnemies();
            OperationPrevStartWave();

            for (int i = 0; i < nextWave.Count; i++)
            {
                SpawnEnemy(nextWave[i]);
                yield return new WaitForSeconds(0.5f);
            }

            AllCurrentWaveEnemiesSpawned = true;
        }
    }

}

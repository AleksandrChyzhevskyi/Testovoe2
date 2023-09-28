using DefaultNamespace;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Global
{
    public class FactoryElements : MonoBehaviour
    {
        [SerializeField] private PlayerStats _player;
        [SerializeField] private CointsPool _cointsPool;
        [SerializeField] private LewelMap _lewelMap;

        public PlayerStats CreatePlayer(Vector3 positionSpawn, InputManager inputManager, FollowCamera followCamera,
            Transform conteiner) =>
            InstantiatePlayer(positionSpawn, inputManager, followCamera, conteiner);

        public List<Coin> CreateCoints(Transform[] positions)
        {
            List<Coin> coints = new List<Coin>();

            for (int i = 0; i < positions.Length; i++)
            {
                Coin coin = _cointsPool.CreateCoin();
                coin.transform.position = positions[i].position;
                coints.Add(coin);
            }

            return coints;
        }

        public LewelMap CreateLewelMap() => Instantiate(_lewelMap, Vector3.zero, quaternion.identity);

        private PlayerStats InstantiatePlayer(Vector3 positionSpawn, InputManager inputManager,
            FollowCamera followCamera,
            Transform conteiner)
        {
            PlayerStats player = Instantiate(_player, positionSpawn, Quaternion.identity, conteiner);
            player.Instans(inputManager, followCamera);
            return player;
        }
    }
}
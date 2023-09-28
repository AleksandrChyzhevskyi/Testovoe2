using UnityEngine;

public class CointsPool : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    
    private int _count = 5;
    private bool _autoExpand = true;
    private PoolMono<Coin> _pool;

    private void Awake()
    {
        _pool = new PoolMono<Coin>(_coin, _count, transform);
        _pool.AutoExpand = _autoExpand;
    }

    public Coin CreateCoin() => _pool.GetFreeElement();
}
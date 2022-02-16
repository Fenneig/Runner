using UnityEngine;

namespace Runner.ObjectPool
{
    public class PoolItem : MonoBehaviour
    {
        private int _id;
        private Pool _pool;

        public void Release()
        {
            _pool.Release(_id, this);
        }

        public void Retain(int id, Pool pool)
        {
            _id = id;
            _pool = pool;
        }
    }
}
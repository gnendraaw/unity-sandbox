using Sandbox.Extension;
using UnityEngine;

namespace Sandbox.Singleton
{
    public class EnemyBuilder {
        EnemyType type;

        public EnemyBuilder SetType(EnemyType type) {
            this.type = type;
            return this;
        }

        public Enemy GetProduct() {
            var instance = GameObject.Instantiate(type.Prefab);
            instance.SetActive(false);

            var enemy = instance.GetOrAdd<Enemy>();
            enemy.SetType(type);

            return enemy;
        }
    }
}


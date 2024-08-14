namespace Sandbox.Playground.Shooter
{
    public class ProjectileCreator {
        private static ProjectileCreator instance;
        public static ProjectileCreator Instance => instance ??= new ProjectileCreator();

        private readonly ProjectilePool pool;

        private ProjectileCreator() {
            var builder = new ProjectileBuilder();
            var director = new ProjectileDirector();
            pool = new ProjectilePool(builder, director);
        }

        public Projectile CreateProjectile(ProjectileData data) => pool.Get(data);
        public void Despawn(Projectile projectile) => pool.Release(projectile);
    }
}


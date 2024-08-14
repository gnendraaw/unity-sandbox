namespace Sandbox.Playground.Shooter
{
    public interface IProjectileBuilder {
        void Reset();
        void SetProjectileData(ProjectileData data);
        void SetMover(IProjectileMover mover);
    }
}


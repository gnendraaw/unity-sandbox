namespace Ardell.EventBus {
    public interface IEvent {

    }

    public struct PlayerEvent : IEvent {
        public int Health;
        public int Mana;
    }

    public struct TestEvent : IEvent {

    }
}

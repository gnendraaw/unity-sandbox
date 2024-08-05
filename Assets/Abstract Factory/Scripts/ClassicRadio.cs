namespace Sandbox.AbstractFactory
{
    public class ClassicRadio : IRadio {
        public void TurnOff() {
            UnityEngine.Debug.Log($"ClassicRadio.TurnOf");
        }

        public void TurnOn() {
            UnityEngine.Debug.Log($"ClassicRadio.TurnOn");
        }
    }
}
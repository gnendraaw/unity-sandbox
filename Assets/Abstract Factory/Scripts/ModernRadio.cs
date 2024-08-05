namespace Sandbox.AbstractFactory
{
    public class ModernRadio : IRadio {
        public void TurnOff() {
            UnityEngine.Debug.Log($"ModernRadio.TurnOff");
        }

        public void TurnOn() {
            UnityEngine.Debug.Log($"ModernRadio.TurnOn");
        }
    }
}
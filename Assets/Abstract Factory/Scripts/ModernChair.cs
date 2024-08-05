namespace Sandbox.AbstractFactory
{
    public class ModernChair :  IChair {
        public void SitOn() {
            UnityEngine.Debug.Log($"ModernChair.SitOn");
        }
    }
}
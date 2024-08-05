namespace Sandbox.AbstractFactory
{
    public class ClassicChair :  IChair {
        public void SitOn() {
            UnityEngine.Debug.Log($"ClassicChair.SitOn");
        }
    }
}
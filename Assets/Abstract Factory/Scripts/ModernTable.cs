namespace Sandbox.AbstractFactory
{
    public class ModernTable : ITable {
        public void PutStuff() {
            UnityEngine.Debug.Log($"ModernTable.PutStuff");
        }
    }
}
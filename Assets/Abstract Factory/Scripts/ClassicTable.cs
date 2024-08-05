namespace Sandbox.AbstractFactory
{
    public class ClassicTable : ITable {
        public void PutStuff() {
            UnityEngine.Debug.Log($"ClassicTable.PutStuff");
        }
    }
}
namespace Sandbox.AbstractFactory
{
    public class ClassicFurnitureFactory : IFurnitureFactory {
        public IChair CreateChair() {
            return new ClassicChair();
        }

        public ITable CreateTable() {
            return new ClassicTable();
        }

        public IRadio CreateRadio() {
            return new ClassicRadio();
        }
    }
}
namespace Sandbox.AbstractFactory
{
    public class ModernFurnitureFactory : IFurnitureFactory {
        public IChair CreateChair() {
            return new ModernChair();
        }

        public ITable CreateTable() {
            return new ModernTable();
        }

        public IRadio CreateRadio() {
            return new ModernRadio();
        }
    }
}
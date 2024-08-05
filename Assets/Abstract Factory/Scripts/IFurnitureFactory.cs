namespace Sandbox.AbstractFactory
{
    public interface IFurnitureFactory {
        IChair CreateChair();
        ITable CreateTable();
        IRadio CreateRadio();
    }
}
namespace CataTombs.Movement
{
    public interface IRotatable
    {
        // rotate unit to left-front tile
        public void TurnLeft();

        // rotate unit to right-front tile
        public void TurnRight();
    }
}
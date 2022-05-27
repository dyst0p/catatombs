namespace CataTombs.Movement
{
    public interface IWalkable
    {
        // go to tile in frond direction
        public void GoForward();

        // go to tile in back direction
        public void GoBackward();
    }
}
namespace WormsWorld
{
    public class NameGenerator
    {
        private const string BaseName = "Worm";
        private int _wormNum = 0;

        public string GetNewName()
        {
            _wormNum++;
            return BaseName + _wormNum;
        }
    }
}


namespace ClassLibraryHSE1course
{
    public interface IInit: ICloneable
    {
        void Show();
        void Init();
        public object Clone();
        void RandomInit(int x, int y);
    }
}

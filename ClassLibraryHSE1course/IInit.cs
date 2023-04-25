

namespace ClassLibraryHSE1course
{
    public interface IInit: ICloneable
    {
        void Show(int ln);
        void Init();
        public object Clone();
        void RandomInit(int x, int y);
    }
}

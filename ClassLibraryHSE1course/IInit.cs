

namespace ClassLibraryHSE1course
{
    public interface IInit: ICloneable,IComparable
    {
        void Show(int ln);
        void Init();
        public object Clone();
        public int CompareTo(object? obj);
        void RandomInit(int x, int y);
    }
}

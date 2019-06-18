namespace Se7en.OpenCvSharp {

    public interface IVec<T> where T : struct {

        T this[int i] {
            get;
            set;
        }
    }
}
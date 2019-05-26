using System.Collections.Generic;

namespace dotnet
{
    public interface MatrixInverter
    {
        Matrix Invert(Matrix matrix);
        IEnumerable<Matrix> Invert(IEnumerable<Matrix> matrixes);
    }
}
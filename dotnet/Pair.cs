namespace dotnet
{
    public class Pair
    {
        public Matrix Matrix { get; set; }
        public double Determinant { get; set; }

        public Pair(Matrix matrix)
        {
            Matrix = matrix;
            Determinant = 0.0;
        }

        public override string ToString()
        {
            string result = this.Matrix.ToString();
            result += "Det: ";
            result += Determinant.ToString();
            result += "\n";

            return result;
        } 
    }
}
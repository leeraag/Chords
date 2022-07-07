namespace Chords
{
    internal class Equation
    {
        public int nP;
        public double a;
        public double b;
        public double e;
        public int[] arrP;

        public Equation(int nP, double a, double b, double e, int[] arrP)
        {
            this.nP = nP;
            this.a = a;
            this.b = b;
            this.e = e;
            this.arrP = arrP;
        }
    }
}
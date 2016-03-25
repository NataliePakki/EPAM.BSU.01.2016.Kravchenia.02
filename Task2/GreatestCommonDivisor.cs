using System;
using System.Diagnostics;

namespace Task2 {
    public static class GreatestCommonDivisor{
        public static int EuclideanMethod(int a, int b){
            return Gcd(GcdEuclide, a, b);
        }
        public static int EuclideanMethod(out double time,int a, int b)
        {
            return Gcd(GcdEuclide, out time, a, b );
        }

        public static int EuclideanMethod(int a, int b, int c){
            return Gcd(GcdEuclide, a, b, c);
        }
        public static int EuclideanMethod(out double time, int a, int b, int c)
        {
            return Gcd(GcdEuclide, out time, a, b, c);
        }
        public static int EuclideanMethod(out double time, params int[] values) {
            return Gcd(GcdEuclide, out time, values);
        }
        public static int EuclideanMethod(params int[] values){
            return Gcd(EuclideanMethod,values);
        }

        public static int SteinMethod(int a, int b){
            return Gcd(GcdStein,a, b);
        }

        public static int SteinMethod(out double time, int a, int b) {
            return Gcd(GcdStein,out time , a, b);
        }
        public static int SteinMethod(out double time, int a, int b, int c) {
            return Gcd(GcdStein,out time, a, b, c);
        }
        public static int SteinMethod(int a, int b, int c){
            return Gcd(GcdStein,a, b, c);
        }
        public static int SteinMethod(params int[] values) {
            return Gcd(GcdStein, values);
        }
        public static int SteinMethod(out double time, params int[] values){
            return Gcd(GcdStein,out time, values);
        }
        
        public static int Gcd(Func<int, int, int> g,out double time, int a, int b) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = Gcd(g, a, b);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }
        public static int Gcd(Func<int, int, int> g, int a, int b ){

            return b > a ? g(b,a) : g(a,b);
        }

        public static int Gcd(Func<int, int, int> g,out double time, int a, int b, int c)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = Gcd(g, a, b, c);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }
        public static int Gcd(Func<int, int, int> g, int a, int b,int c){
            return Gcd(g, a, Gcd(g, b, c));
        }

        public static int Gcd(Func<int, int, int> g, params int[] values) {
            if (values.Length < 2)
                throw new ArgumentException("Arguments must be at least 2");
            int result = values[0];
            for (int i = 1; i < values.Length; i++){
                result = g(values[i], result);
            }
            return result;
        }

        public static int Gcd(Func<int, int, int> g,out double time, params int[] values) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = Gcd(g,values);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }



        private static int GcdEuclide(int a, int b) {
            if (a == 0 && b == 0)
                throw new ArgumentException("Two arguments must not be zero");
            return b != 0 ? GcdEuclide(b, a%b) : Math.Abs(a);
        }

        private static int GcdStein(int a, int b) {
            if(a < 0 || b < 0)
                throw new ArgumentException("Argument nust be positive.");
            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;
            if ((a%2 == 0) && (b%2 == 0)) return 2*GcdStein(a/2, b/2);
            if ((a%2 == 0) && (b%2 != 0)) return GcdStein(a/2, b);
            if ((a%2 != 0) && (b%2 == 0)) return GcdStein(a, b/2);
            return GcdStein(b, Math.Abs(a - b));
        }
    }
}

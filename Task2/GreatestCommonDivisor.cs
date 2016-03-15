﻿using System;
using System.Diagnostics;

namespace Task2 {
    public static class GreatestCommonDivisor {
        public static int EuclideanMethod(out double time,int a, int b) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = EuclideanMethod(a, b);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }
        public static int EuclideanMethod(int a, int b) {
            if (a == 0 && b == 0)
                throw new ArgumentException("Two arguments must not be zero");
            return b > a ? GcdEuclide(b, a) : GcdEuclide(a, b);
        }

        public static int EuclideanMethod(out double time, int a, int b, int c) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = EuclideanMethod(a, b, c);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }

        public static int EuclideanMethod(int a, int b, int c) {
            return EuclideanMethod(a,EuclideanMethod(b,c));
        }

        public static int EuclideanMethod(out double time, params int[] values) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = EuclideanMethod(values);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }

        public static int EuclideanMethod(params int[] values) {
            if (values.Length < 2)
                throw new ArgumentException("Arguments must be at least 2");
            int result = values[0];
            for (int i = 1; i < values.Length; i++){
                result = EuclideanMethod(values[i], result);
            }
            return result;
        }

        public static int SteinMethod(out double time, int a, int b) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = SteinMethod(a, b);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }

        public static int SteinMethod(int a, int b) {
            if (a < 0 || b < 0)
                throw new ArgumentException("Arguments must be nonegative.");
            return GcdStein(a, b);
        }

        public static int SteinMethod(out double time, int a, int b, int c) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = SteinMethod(a, b, c);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }

        public static int SteinMethod(int a, int b, int c) {
            return SteinMethod(a,SteinMethod(b,c));
        }

        public static int SteinMethod(out double time, params int[] values) {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = SteinMethod(values);
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
            return gcd;
        }

        public static int SteinMethod(params int[] values) {
            if (values.Length < 2)
                throw new ArgumentException("Arguments must be at least 2");
            int gcd = values[0];
            for (int i = 1; i < values.Length; i++){
                gcd = SteinMethod(values[i], gcd);
            }
            return gcd;
        }


        private static int GcdEuclide(int a, int b) {
            return b != 0 ? GcdEuclide(b, a%b) : Math.Abs(a);
        }

        private static int GcdStein(int a, int b) {
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

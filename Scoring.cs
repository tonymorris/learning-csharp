using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring {

    class Program {

        static void Main(string[] args) {

            int[,] results ={
                              { 4, 7, 9, 3, 8, 6},
                              { 4, 8, 6, 4, 8, 5}

                             };
            
            PrintCompetitors(results);
            var judge = HighestJudge(results);
            Console.WriteLine(Winner(Max(Scores(results))));
            Console.WriteLine(JudgeStr(judge));
            
            Console.ReadLine();

        }//end Main

        static string Winner(Tuple<int, int> t)
        {
            var r = new StringBuilder();

            r.Append("the winner is competitor ");
            r.Append(t.Item2 + 1);
            r.Append(" with a score of ");
            r.Append(t.Item1);

            return r.ToString();
        }

        static int[] Scores(int[,] x)
        {
            var b = BeNice(x);
            int[] r = new int[b.Length];

            for(int i = 0; i < b.Length; i++)
            {
                r[i] = Score(b[i]);
            }
            return r;
        }

        static string JudgeStr(Tuple<int, double, int> t)
        {
            var r = new StringBuilder();

            r.Append("the highest scoring judge ");
            r.Append(t.Item3 + 1);
            r.Append(" with a total of ");
            r.Append(t.Item1);
            r.Append(" and with the average grade of ");
            r.Append(t.Item2);
            
            return r.ToString();
        }

        static void PrintCompetitors(int[,] x)
        {
            int[][] a = BeNice(x);

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(CompetitorStr(i, a[i]));
                Console.WriteLine();
            }
        }

        static string CompetitorStr(int i, int[] x)
        {
            var r = new StringBuilder();

            r.Append("Competitor ");
            r.Append(i + 1);
            r.Append(" your scores are ");
            r.Append(ArrayStr(x));
            r.Append("\n        ");
            r.Append("and your score was ");
            r.Append(Score(x));

            return r.ToString();
        }

        static string ArrayStr(int[] x)
        {
            var r = new StringBuilder();

            foreach(int el in x)
            {
                r.Append(el);
                r.Append(' ');   
            }

            return r.ToString();
        }
        // total, average, index
        static Tuple<int, double, int> HighestJudge(int[,] x)
        {
            int total = 0;
            int index = -1;

            var y = BeNice(Transpose(x));
            
            for(int i = 0; i < y.Length; i++)
            {
                var tmm = TotalMinMax(y[i]);
                if(tmm.Item1 > total)
                {
                    total = tmm.Item1;
                    index = i;
                }
            }
           
            double avg = total / y[0].Length;

            return new Tuple<int, double, int>(total, avg, index);
        }


        /*
        Assume Length > 1.
        */
        static int Score(int[] x)
        {
            Tuple<int, int, int> totalminmax = TotalMinMax(x);

            return totalminmax.Item1 - totalminmax.Item2 - totalminmax.Item3;
          
        }

        // index, maximum
        static Tuple<int, int> Max(int[] t)
        {
            int max = -1;
            int index = -1;

            for(int i = 0; i < t.Length; i++)
            {
                if(t[i] > max)
                {
                    max = t[i];
                    index = i;
                }
            }

            return new Tuple<int, int>(max, index);
        }

        /*
        Safe programming with arrays is not a thing.
        Assume Length > 0.
        Else have a bad day.
        */
        static Tuple<int, int, int> TotalMinMax(int[] t)
        {
            int min = t[0];
            int max = t[0];
            int total = t[0];

            for(int i = 1; i < t.Length; i++)
            {
                if(t[i] < min)
                {
                    min = t[i];
                }

                if(t[i] > max)
                {
                    max = t[i];
                }

                total += t[i];
            }

            return new Tuple<int, int, int>(total, min, max);
        }

        static int[][] BeNice(int[,] x)
        {
            int[][] r = new int[x.GetLength(0)][];

            for (int i = 0; i < x.GetLength(0); i++) {
                r[i] = new int[x.GetLength(1)];
                for(int j = 0; j < x.GetLength(1); j++)
                {
                    r[i][j] = x[i, j];
                }
            }

            return r;
        }

        static int[,] Transpose(int[,] x)
        {
            int[,] r = new int[x.GetLength(1), x.GetLength(0)];

            for(int i = 0; i < x.GetLength(1); i++)
            {
                for(int j = 0; j < x.GetLength(0); j++)
                {
                    r[i, j] = x[j, i];
                }
            }

            return r;
        }

    }//end class
}//end namespace

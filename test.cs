using System.Collections.Generic;
using System;
using System.IO;

namespace Level1Space
{
    class Program
    {
        static void Main(string[] args)
        {

        using (TextWriter fil = new StreamWriter("stdout.txt", true)) {
        try {

        int[] battalion = {2,2, 2,2, 3,4};
        int n = -1;
        try {
            n = Level1.ConquestCampaign(3,4, 3, battalion);
        } catch(Exception ex) {
           fil.WriteLine("ERR03.5\n"); return;
        }
        if(n != 3) { fil.WriteLine("ERR03.2\n") ; return; }


        int[] battalion2 = {1,1, 1,2, 1,3, 2,1, 2,2, 2,3};
        n = Level1.ConquestCampaign(2,3, 6, battalion2);
        if(n != 1) { fil.WriteLine("ERR03.3\n") ; return; }

        int[] battalion3 = {3,3, 3,3, 3,3, 3,3};
        n = Level1.ConquestCampaign(5,5, 4, battalion3);
        if(n != 5) { fil.WriteLine("ERR03.4\n") ; return; }

        // граничные условия длиной 1


         fil.WriteLine("PASSED\n");
       }
       catch(Exception ex) {
           fil.WriteLine("ERR03.0\n"+ex.ToString()+"\n");
         }

       }
    }
 }
}


namespace Level1Space
{
    public static class Level1
    {
                public static int ConquestCampaign(int N, int M, int L, int[] battalion)
        {
            int[,] dynarr = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    dynarr[i, j] = 0;
                }
            }
            for (int i = 0; i < battalion.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    int a = battalion[i];
                    int b = battalion[i + 1];
                    dynarr[a, b] = 1;
                }
                else
                    continue;
            }
            int day = 1;
            bool prizn = false;
            while (prizn == false)
            {
                int k = 0;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (dynarr[i, j] != 0)
                            dynarr[i, j]++;
                        if (dynarr[i, j] >= 2)
                        {
                            if (i > 0)
                                dynarr[i - 1, j]++;
                            if (i < N - 1)
                                dynarr[i + 1, j]++;
                            if (j > 0)
                                dynarr[i, j - 1]++;
                            if (j < M - 1)
                                dynarr[i, j + 1]++;
                        }
                    }
                }
                day++;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (dynarr[i, j] == 0)
                            k++;
                    }
                }
                if (k == 0)
                {
                    prizn = true;
                    break;
                }
            }
            return day;
        }
    }
}

import java.io.*;
import java.util.*;
import java.util.regex.Pattern;

public class test {

  static boolean cmp(int[] a1, int[] a2)
        {
          if(a1.length != a2.length) return false;
          for(int i=0; i<a1.length; i++)
           if(a1[i] != a2[i]) return false;
          return true;
        }


  public static void main(String[] args){

    try {
        File file = new File( "stdout.txt" );
        if ( ! file.exists( ) ) file.createNewFile( );
        FileWriter filw = new FileWriter( file.getAbsoluteFile( ) );
        BufferedWriter fil = new BufferedWriter( filw );

        int n = -1;
        try {
            n = Level1.SumOfThe(3, new int[] {2, 3, 5});
        } catch(Exception ex) {
           fil.write("ERR07.2\n"); fil.close(); return;
        }
        if( n != 5 ) { fil.write("ERR07.3\n") ; fil.close(); return; }

        n = Level1.SumOfThe(5, new int[] {10, -25, -45, -35, 5});
        if( n != -45 ) { fil.write("ERR07.4\n") ; fil.close(); return; }

        n = Level1.SumOfThe(7, new int[] {100, -50, 10, -25, 90, -35, 90});
        if( n != 90 ) { fil.write("ERR07.5\n") ; fil.close(); return; }

        n = Level1.SumOfThe(4, new int[] {-100, -20, -70, -10});
        if( n != -100 ) { fil.write("ERR07.6\n") ; fil.close(); return; }

        n = Level1.SumOfThe(4, new int[] {0, 0, 0, 0});
        if( n != 00 ) { fil.write("ERR07.7\n") ; fil.close(); return; }



        fil.write( "PASSED\n" );
        fil.close( );
       }
       catch(Exception ex) {
        System.out.println("ERROR 7.0" + ex);
      }

  }
}


class Level1
{
    public static int SumOfThe(int N, int [] data)
      {
        int sum = 0, res = 0;
        for (int i = 0; i < N; i++) {
            for (int j =0; j < N; j++) {
                if (j != i) {
                    sum +=  data[j];
                }
            }
            if (data [i] == sum) {
                res = sum;
            }
            sum = 0;
        }
        return res;
      }
}

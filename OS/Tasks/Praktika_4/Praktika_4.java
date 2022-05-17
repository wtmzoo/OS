
/*
Online Java - IDE, Code Editor, Compiler

Online Java is a quick and easy tool that helps you to build, compile, test your programs online.
*/

public class Main
{
    public static void main(String[] args) {
        long startTime = System.nanoTime();
        
        int a=0, b=3, c=3;
        for ( int i=0; i<100000000; i++ )
            a += b*2 + c - i;
            
        long endTime = System.nanoTime();
        
        long duration = (endTime - startTime)/1000000;  
        
        System.out.println(a);
        System.out.println(duration + " ms");
    }
}

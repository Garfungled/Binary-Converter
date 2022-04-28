using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Program{
       public static void Main(){
           Console.WriteLine("String to Binary, or Binary to String?[1, or 2]");
           Console.Write(">>");
           string? answer = Console.ReadLine();
           if(answer == null){answer = "NULL";}

           if(answer == "1"){
               Console.WriteLine("Enter a string to be converted into a binary");
               Console.Write(">>");
                string? input = Console.ReadLine();
                if(input == null){input = "NULL";}
                //Uses the two methods to go from string to binary
                Console.WriteLine($"Your string to binary: {SplitBinary(StrToBin(input))}");
            }else if(answer == "2"){
                Console.WriteLine("Enter a binary to be converted to a string");
                Console.Write(">>");
                string? input = Console.ReadLine();
                if(input == null){input = "NULL";}
                
                //Check to see if method works. Binary is very specific so it can't just take in random 0's and 1's.
                if(BinToStr(input) == null){
                    Console.WriteLine("Not a real binary text, try again");
                }else{
                    Console.WriteLine($"Your binary to string: {BinToStr(input)}");
                }
            }else{
                Console.WriteLine("You have one job...");
            }
            
        }
        
        //Uses stringbuilder since it's much easier than going back and forth with arrays and lists. Also Append is fun
        public static string StrToBin(string str){
            StringBuilder sb = new StringBuilder();
            foreach(var i in str.ToArray()){
                sb.Append(Convert.ToString(i, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        
        //This is a bit wacky
        public static string BinToStr(string str){
            //Have to get rid of all the spaces between binary segments which are by 8.
            str = String.Concat(str.Where(c => !Char.IsWhiteSpace(c)));
            try{
                List<Byte> byteList = new List<Byte>();

                for (int i = 0; i < str.Length; i += 8){
                    byteList.Add(Convert.ToByte(str.Substring(i, 8), 2));
                }
                return Encoding.ASCII.GetString(byteList.ToArray());
            }catch(ArgumentOutOfRangeException){
                return "DIDN'T WORK!";
            }
            
        }
        
        //Splitting the binary so it actually looks like 8 segment binary and not jarbled mess of 0's and 1's
        //I wanted to create a seperate method as to not fill the orginal method too much
        public static string SplitBinary(string str){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++){
                if(i % 8 == 0){
                    sb.Append(' ');
                }
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
    }
}

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
                Console.WriteLine($"Your string to binary: {SplitBinary(StrToBin(input))}");
            }else if(answer == "2"){
                Console.WriteLine("Enter a binary to be converted to a string");
                Console.Write(">>");
                string? input = Console.ReadLine();
                if(input == null){input = "NULL";}

                if(BinToStr(input) == null){
                    Console.WriteLine("Not a real binary text, try again");
                }else{
                    Console.WriteLine($"Your binary to string: {BinToStr(input)}");
                }
            }else{
                Console.WriteLine("You have one job...");
            }
            
        }

        public static string StrToBin(string str){
            StringBuilder sb = new StringBuilder();
            foreach(var i in str.ToArray()){
                sb.Append(Convert.ToString(i, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinToStr(string str){
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
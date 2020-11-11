using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ringba_test
{
    class Program
    {
    static void aboutPrefixs(String[] WordsArray) 
    { 
        var prefixCount= new Dictionary<string,int>();
        var numbers = new List<int>();      
        int size = WordsArray.Length; 
        foreach(var word in WordsArray)
        {   
            for(int i = 1; i < word.Length; i++)
            {
                if(prefixCount.ContainsKey(word.Substring(0, i)))
                    prefixCount[word.Substring(0, i)]++;
                else
                    prefixCount[word.Substring(0, i)] = 1;                
            }
            
        }
        prefixCount = prefixCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        Console.WriteLine( "*************** THE MOST TWO COMMON PREFIX  *********************************** "); 
        Console.WriteLine("The most common 2 character prefix and the number of occurrences in the text file :\n "+
                        "   first is : {0}  accured  {1}"+
                        "\n     Second is : {2} accured : {3}",
                        prefixCount.ElementAt(0).Key,prefixCount.ElementAt(0).Value,
                        prefixCount.ElementAt(1).Key, prefixCount.ElementAt(1).Value);
    Console.WriteLine("///////////---FROM NOW ON PLEASE BE PATIENT PRINTING ALL THESE WORDS TAKES TIME-----////////////");
    Console.WriteLine("Words that contain the first most commun orefix : {0} ",prefixCount.ElementAt(0).Key);
    WordsContain( WordsArray, prefixCount.ElementAt(0).Key);
    Console.WriteLine("Words that contain the second most commun orefix : {0} ",prefixCount.ElementAt(1).Key);
    WordsContain( WordsArray, prefixCount.ElementAt(1).Key);
    Console.WriteLine("**********************BONUS******************************************");
    foreach (KeyValuePair<string, int> kvp in prefixCount)
        {
            if(kvp.Key.Length >1  && kvp.Value>1){
                Console.WriteLine("-------------------------Prefix  & frecuency  & List of words that contain that prefix -----------------------");
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                 WordsContain( WordsArray, kvp.Key);
            }
              
        }
     Console.WriteLine("**********************END OF BONUS******************************************");

    } 

    //words that contain ..
    public static void WordsContain(String[] WordsArray,string prefix){
        List<string> WordsList =new List<string>() ;
       // var result = WordsList.Any(o => o.StartsWith(prefix));
        for(int i = 0; i < WordsArray.Length ; i++)
        {
            if(WordsArray[i].StartsWith(prefix) == true){
                WordsList.Add(WordsArray[i]);
            } 
        }
        Console.WriteLine(String.Join(",", WordsList));
    }

    //add spaces between words 
    public static string SpacesFromCamel(string value)
        {
            if (value.Length > 0)
            {
                var result = new List<char>();
                char[] array = value.ToCharArray();
                foreach (var item in array)
                {
                    if (char.IsUpper(item) && result.Count > 0)
                    {
                        result.Add(' ');
                    }
                    result.Add(item);
                }

                return new string(result.ToArray());
            }
            return value;
        }
        // Function to find the count of words with a CamelCase separetor 
        //concidering that the UpperCase words are between 65 and 90 in the ASCII code 
        //and counting the frequency of  a letter 
        static int countWords(String str)  
        {  
            //counting words /number of UpperCase letters
            int count = 0;  
            //counting the lettres frequency 
            var characterCount= new Dictionary<char,int>();
            for (int i = 0; i < str.Length ; i++)  
            {  
                /// if you take of the char.ToUpper() function will give you all letters frequency with small and upper case separated 
                if(characterCount.ContainsKey(char.ToUpper(str[i]))){
                    characterCount[char.ToUpper(str[i])]++;
                }else{
                     characterCount[char.ToUpper(str[i])] = 1;
                }
                //add a word / an upperCase letter
                if (str[i] >= 65 && str[i] <= 90)  
                    count++;  

            }  
            //getting letters and frequency from dictionary 
            Console.WriteLine("- How many of each letter are in the file ?");
            foreach(var pair in characterCount)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            return count;  
        }  
        static void  mostCommunWord(string[] WordsArray)  
        {  
            var characterCount= new Dictionary<string,int>();
            foreach(var c in WordsArray)
            {
                if(characterCount.ContainsKey(c))
                    characterCount[c]++;
                else
                    characterCount[c] = 1;
            }
            characterCount = characterCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("- The most common word is : ' {0} ' it has been seen  : {1} time",characterCount.First().Key,characterCount.First().Value); 

        }
        static void Main(string[] args)
        {
            Console.WriteLine("*********** Hello World ---- Let's the game begin :D **********************************");
            //downloading the file from http://ringba-test-html.s3-website-us-west-1.amazonaws.com/TestQuestions/output.txt
            try
            {
                var URL = "http://ringba-test-html.s3-website-us-west-1.amazonaws.com/TestQuestions/output.txt"; 
                var wc = new System.Net.WebClient();
                wc.DownloadFile( URL, @"data");
                Console.WriteLine("The file is Already downloaded let's preceed!");
            }
            catch 
            {
                Console.WriteLine("The file is being downloaded !");
            }
            // the file path 
            //--the same folder 
            Console.WriteLine("You can find the file in the same directory ;)");
            //reading from file 
            string contents = File.ReadAllText(@"data");
            //counting words will give us the number of Capitalized letters 
            Console.WriteLine("**************** HOW MANY LETTERS ARE CAPITALIZED IN THE FILE ***************************"); 
            Console.WriteLine(" {0} Letter",countWords(contents)); 
            
            string[] WordsArray = SpacesFromCamel(contents).Split(" ");
            Console.WriteLine( "*************** The MOST COMMUN WORD /TIMES SEEN  **************************************"); 
            mostCommunWord(WordsArray);
            Console.WriteLine( "***************ALL ABOUT PREFIXS  ******************************************************"); 
            aboutPrefixs(WordsArray);
            Console.WriteLine("********************** THE END -GOOD BYE WORLD ******************************************");
            
        }
    }
}

using System;
using DeepAI;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;


namespace ChatAiTest
{
    class Program
    {

        private static string _msg { get; set; }
        private static string _api_key { get; set; }
        private static DeepAI_API _api { get; set; }


        static void Main(string[] args)
        {

            //Your API Key from www.deepai.com
            _api_key = "YOUR_API_KEY_HERE";
            
            
            //Connect to the DeepAI API with the given key
            _api = new DeepAI_API($"{_api_key}");
            Menu();
            

           
        }

        public static void AiMain ()
        {
            //We send a request to the API for use of the text-generator,
            //and we send the data in _msg to the AI.
            Console.WriteLine("\nSending...");
            StandardApiResponse resp = _api.callStandardApi("text-generator", new{ text = $"{_msg}",});
            Console.WriteLine("\n" + resp.output);

            //We display the menu again to maintain a loop
            Menu();
        }
        //Bool to check if user has prompted menu before
        public static bool isNew = true;
        public static void Menu()
        {
          //Get user input, show 2 different outputs based on
          //if the user has seen the menu before
            if (isNew)
            {
                Console.WriteLine("\n\t       v1.0.0");
                Console.WriteLine("\t----**************----");
                Console.WriteLine("\t----**************----");
                Console.WriteLine("\t----**************----");
                Console.WriteLine("Type a message: ");
                _msg = Console.ReadLine();
                isNew = false;

            } else if (!isNew)
            {
                
                Console.WriteLine("Type a message:");
                _msg = Console.ReadLine();

            }
            //Send Input to AI Maincode
            AiMain();


        }
    }
}
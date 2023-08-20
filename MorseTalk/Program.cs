using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MorseTalk
{
    internal class Program
    {
        static void Title()
        {
            Console.Clear();
            Console.WriteLine();
            //title
            Console.WriteLine("=============================================================");
            Console.WriteLine("  |\\  /|  //||\\  |||\\\\  //// |||\\  |||||   //|| |||   |||//");
            Console.WriteLine("  ||\\/|| |||  || |||//  \\\\\\\\ ||\\    |||   ///_| |||   |||/");
            Console.WriteLine("  ||||||  \\\\||/  |||\\\\  //// |||/   |||  /// || ||||/ |||\\\\");
            Console.WriteLine("=============================================================");
        }
        static void Start()
        {
            Title();
            {//command list
                Console.WriteLine("\n-------------------------------------------------------------\n" +
                    "   [ Command List ]\n");
                Console.WriteLine("      '1' - From ENG       '3' - Edit Pitch/Speed" +
                                "\n      '2' - From MOR       '4' - Current Settings" +
                              "\n\n      'e' - Exit           'r' - Reset");
                Console.WriteLine("_____________________________________________________________");
            }
            {//notes
                Console.WriteLine("\n   * This program outputs audible Morse Code");
                Console.WriteLine("   * ENG = English Characters ");
                Console.WriteLine("   * MOR = Conventional Morse Code Characters");
            }
            Console.WriteLine("\n=============================================================");
            Console.Write("\n     Press any valid command key to start! ");
        }
        static string ConvertEng(string eng)
        {
            SortedList<char, string> Txt = new SortedList<char, string>();
            Txt.Clear();
            Txt.Add(' ', "/");
            Txt.Add('a', ".-");
            Txt.Add('b', "-...");
            Txt.Add('c', "-.-.");
            Txt.Add('d', "-..");
            Txt.Add('e', ".");
            Txt.Add('f', "..-.");
            Txt.Add('g', "--.");
            Txt.Add('h', "....");
            Txt.Add('i', "..");
            Txt.Add('j', ".---");
            Txt.Add('k', "-.-");
            Txt.Add('l', ".-..");
            Txt.Add('m', "--");
            Txt.Add('n', "-.");
            Txt.Add('o', "---");
            Txt.Add('p', ".--.");
            Txt.Add('q', "--.-");
            Txt.Add('r', ".-.");
            Txt.Add('s', "...");
            Txt.Add('t', "-");
            Txt.Add('u', "..-");
            Txt.Add('v', "...-");
            Txt.Add('w', ".--");
            Txt.Add('x', "-..-");
            Txt.Add('y', "-.--");
            Txt.Add('z', "--..");
            Txt.Add('1', ".----");
            Txt.Add('2', "..---");
            Txt.Add('3', "...--");
            Txt.Add('4', "....-");
            Txt.Add('5', ".....");
            Txt.Add('6', "-....");
            Txt.Add('7', "--...");
            Txt.Add('8', "---..");
            Txt.Add('9', "----.");
            Txt.Add('0', "-----");
            Txt.Add('.', ".-.-.-");
            Txt.Add(',', "--..--");
            Txt.Add('?', "..--..");
            Txt.Add('\'', ".---.");
            Txt.Add('!', "-.-.--");
            Txt.Add('/', "-..-.");
            Txt.Add('(', "-.--.");
            Txt.Add(')', "-.--.-");
            Txt.Add('&', ".-...");
            Txt.Add(':', "---...");
            Txt.Add(';', "-.-.-.");
            Txt.Add('=', "-...-");
            Txt.Add('+', ".-.-.");
            Txt.Add('-', "-....-");
            Txt.Add('_', "..--.-");
            Txt.Add('"', ".-..-.");
            Txt.Add('$', "...-..-");
            Txt.Add('@', ".--.-.");
            string output = "";
            foreach (char c1 in eng)
            {
                bool valid_Char = false;
                foreach (char c2 in Txt.Keys)
                {
                    if (c1 == c2)
                    {
                        output += $"{Txt[c2]} ";
                        valid_Char = true;
                        break;
                    }
                }
                if (!valid_Char)
                {
                    output += "?";
                }
            }
            return output;
        }
        static string Shorten(string input)
        {
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }
        static string Command(out bool cont, ref int pitch, ref int speed)
        {
            string input;
            bool rep;
            string conv;
            cont = true;
            do
            {
                rep = false;
                conv = "";
                ConsoleKeyInfo choice = Console.ReadKey(true);
                switch (choice.KeyChar)
                {
                    case ('1'):
                        Title();
                        Console.Write("\n   * Press 'enter' to exit *");
                        Console.Write("\n  => Message (ENG): ");
                        input = Console.ReadLine().ToLower().Trim();
                        conv = Shorten(ConvertEng(input));
                        break;
                    case ('2'):
                        Title();
                        Console.Write("\n   * Press 'enter' to exit *");
                        Console.Write("\n  => Message (MOR): ");
                        input = Console.ReadLine().Trim();
                        conv = Shorten(input);
                        break;
                    case ('3'):
                        //new pitch setting
                        Title();
                        bool inValid = true;
                        do
                        {
                            try
                            {
                                Console.Write("\n   * Enter 's' to skip *");
                                Console.Write("\n  => New [Pitch] (200 - 3000 hz): ");
                                var newVal = Console.ReadLine();
                                if (newVal == "s")
                                {
                                    inValid = false;
                                }
                                else if (Convert.ToInt32(newVal) >= 200 && Convert.ToInt32(newVal) <= 3000)
                                {
                                    pitch = Convert.ToInt32(newVal);
                                    inValid = false;
                                }
                                Console.WriteLine("  Invalid Entry!");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("  Invalid Entry!");
                            }
                        } while (inValid);
                        //new speed setting
                        Title();
                        inValid = true;
                        do
                        {
                            try
                            {
                                Console.Write("\n   * Enter 's' to skip *");
                                Console.Write("\n  => New [Speed] (100 - 1000 ms): ");
                                var newVal = Console.ReadLine();
                                if (newVal == "s")
                                {
                                    inValid = false;
                                }
                                else if (Convert.ToInt32(newVal) >= 100 && Convert.ToInt32(newVal) <= 1000)
                                {
                                    speed = Convert.ToInt32(newVal);
                                    inValid = false;
                                }
                                Console.WriteLine("  Invalid Entry!");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("  Invalid Entry!");
                            }
                        } while (inValid);
                        break;
                    case ('4'):
                        Title();
                        Console.WriteLine($"\n  => Current Settings\n  [Pitch] : {pitch} hz \n  [Speed] : {speed} ms");                       
                        Console.Write("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ('r'):
                        Title();
                        Console.WriteLine("\n  => Default Settings Applied");
                        pitch = 440;
                        speed = 200;
                        Console.Write("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ('e'):
                        Title();
                        Console.Write("\n  => Exiting in ");
                        for (int i = 3; i > 0; i--)
                        {
                            Thread.Sleep(1000);
                            Console.Write(i + " ");
                        }
                        Thread.Sleep(500);
                        Console.WriteLine("...");
                        Thread.Sleep(500);
                        cont = false;
                        break;
                    default:
                        rep = true;
                        break;
                }
            } while (rep);
            return conv;
        }
        static void check(out bool check)
        {
            check = false;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == (char)13)
                {
                    check = true;
                }
            }
        }
        static void Beep(string conv, int pitch, int speed)
        {
            string temp = conv;
            string test = temp.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            if (test.Length > 0 || test.Contains('?'))
            {
                Console.WriteLine("  Invalid Character Detected!");
                Console.Write("\n  Press any key to continue...");
                Console.ReadKey(true);
            }
            else
            {              
                foreach (char c in conv)
                {
                    bool quit;
                    check(out quit);
                    switch (c)
                    {
                        case ('.'):
                            Console.Beep(pitch, speed);
                            check(out quit);
                            Thread.Sleep(speed);
                            break;
                        case ('-'):
                            Console.Beep(pitch, speed * 3);
                            check(out quit);
                            Thread.Sleep(speed);
                            break;
                        case ('/'):
                            Thread.Sleep(speed);                            
                            break;
                        default:
                            Thread.Sleep(speed);
                            check(out quit);
                            Thread.Sleep(speed);
                            check(out quit);
                            Thread.Sleep(speed);
                            break;
                    }
                    if (quit)
                    {
                        break;
                    }
                }
            
            }
        }
        static void Main(string[] args)
        {

            const int stdPitch = 440;
            const int stdTime = 200;

            int pitch = stdPitch;
            int speed = stdTime;
            bool cont;

            Console.Title = "Morse Talk";
            Console.CursorVisible = false;
            Console.WindowWidth = 61;
            Console.WindowHeight = 25;

            do
            {
                Start();
                Beep(Command(out cont, ref pitch, ref speed), pitch, speed);
            } while (cont);
        }
    }
}
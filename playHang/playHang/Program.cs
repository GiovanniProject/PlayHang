using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace playHang
{
    class Program
    {
        static void Main(string[] args)
        {

            List<playersInfo> listPlayers = new List<playersInfo>();
            playersInfo registerPlayers = new playersInfo();
            Console.WriteLine("Inserisci il tuo Nome:");
            registerPlayers.Name = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo Cognome:");
            registerPlayers.Surname = Console.ReadLine();
            listPlayers.Add(registerPlayers);

            int indexWordFileTxt = 0;

            string wordChooseToFind = null;
            string WordToFind = null;
            HiddenWord trasformToSymbol = new HiddenWord();


            /*Scelta della difficoltà del gioco*/
            string playAgain = null;
            do
            {
                Random RandomClass = new Random();
                int RandomNumber = 0;
                Console.WriteLine("Scegli la difficoltà : ");
                Console.WriteLine("premi '1' principiante");
                Console.WriteLine("premi '2' medio");
                Console.WriteLine("premi '3' professionista");
                string difficult = Console.ReadLine();
                switch (difficult)
                {
                    case "1":
                        {
                            RandomNumber = RandomClass.Next(2, 5);
                            break;
                        }

                    case "2":
                        {
                            RandomNumber = RandomClass.Next(7, 10);
                            break;
                        }
                    case "3":
                        {
                            RandomNumber = RandomClass.Next(12, 15);
                            break;
                        }
                }


                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    String line;
                    indexWordFileTxt = 0;

                    while ((line = sr.ReadLine()) != null)
                    {

                        indexWordFileTxt++;
                        if (indexWordFileTxt == RandomNumber)
                        {

                            wordChooseToFind = line;
                            WordToFind = trasformToSymbol.changeTosymbol(wordChooseToFind);


                        }
                    }
                }

                Console.WriteLine("Trova la seguente parola: ");
                Console.WriteLine(WordToFind);
                Console.WriteLine("Premi invio se sei pronto a giocare");
                Console.ReadLine();

                Console.WriteLine("Inserisci una carattere hai 3 tentativi:");
                string p = Console.ReadLine();

                StringBuilder solutionWord = new StringBuilder(WordToFind);
                HangSession playHangState = new HangSession();


                //bool makeMistake = true;
                playHangState.makeMistake = true;
                string tToSring = null; // necessario per convertire il tipo char del foreach usato sotto 
                //affinché potessi confrontare con la parola da cercare

                playHangState.toEliminateConflict = false;

                {
                    do
                    {
                        do
                        {
                            playHangState.controlStringSymbol = false;
                            playHangState.toEliminateConflict = false;
                            foreach (char t in wordChooseToFind)
                            {

                                tToSring = t.ToString();
                                if (playHangState.indexWordToFind < wordChooseToFind.Length)
                                {

                                    if (p.Equals(tToSring))
                                    {
                                        solutionWord[playHangState.indexWordToFind] = t;
                                        playHangState.controlStateWord = solutionWord.ToString();
                                        playHangState.makeMistake = false;

                                    } playHangState.indexWordToFind++;
                                }

                            } playHangState.indexSubWordToComplete++;
                            if (playHangState.makeMistake == true)
                            {
                                playHangState.errState++;
                                playHangState.attempt = 3 - playHangState.errState;
                                if (playHangState.attempt == 0)
                                {
                                    playHangState.toEliminateConflict = true;
                                    break;
                                }
                                Console.WriteLine("Attenzione! ti sono rimasti {0} tentativi", playHangState.attempt);
                            }
                            if ((playHangState.attempt != 0) && (playHangState.makeMistake == true))
                            {
                                Console.WriteLine(solutionWord);
                                p = Console.ReadLine();
                                playHangState.toEliminateConflict = true;
                                playHangState.indexWordToFind = 0;
                            }
                        } while ((playHangState.errState <= 2) && (playHangState.makeMistake != false));
                        try
                        {
                            foreach (char control in playHangState.controlStateWord)  //necessari per fare un controllo se nella parola sono presenti _.___
                            {
                                if ((control == 95) || (control == 46))
                                {
                                    playHangState.controlStringSymbol = true;
                                    break;
                                }
                            }
                        }
                        catch
                        { }
                        if ((playHangState.errState == 3) || (playHangState.controlStringSymbol == false))
                        {
                            break;

                        }

                        if (playHangState.toEliminateConflict == false)
                        {
                            Console.WriteLine(solutionWord);
                            p = Console.ReadLine();
                        }


                        playHangState.indexWordToFind = 0;
                        playHangState.makeMistake = true;
                    } while (playHangState.indexSubWordToComplete <= wordChooseToFind.Length);

                    if (playHangState.errState > 2)
                    {
                        Console.WriteLine("Spiacente " + registerPlayers.Name + " hai perso!");
                        Console.WriteLine("La parola da cercare era: " + wordChooseToFind);

                    }
                    else
                    {
                        Console.WriteLine(wordChooseToFind);
                        Console.WriteLine("Congratulazione " + registerPlayers.Name + " hai vinto!");

                    }
                    Console.WriteLine("Premi invio per continuare");
                    Console.ReadLine();
                    Console.WriteLine("Vuoi fare un'altra partita? Premi:");
                    Console.WriteLine("1:Rigioca");
                    Console.WriteLine("2:Exit");
                    playAgain = Console.ReadLine();

                }

            } while (playAgain.Equals("1"));
            if (playAgain == "2")

            {
                Console.WriteLine("Ti aspettiamo " + registerPlayers.Name +" per un'altra partita!");
                Console.ReadLine();
            }
        }
    }
}

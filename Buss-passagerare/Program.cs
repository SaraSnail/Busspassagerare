

using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Bussen //namespace är så om jag vill använda koden här i ett annat program kan jag på ett sätt "länka" det genom namespace



{

    class Passagerare
    {
        public Passagerare()//Den är tom så att klassen inte måste ha namn eller ålder innan för att fungera
        {

        }

        public string Namn { get; set; }//Namn kommer ta (get) och ställa in (set) namn som samlas i listan
        public int Ålder { get; set; }
        public Passagerare(string namn, int ålder)//Tar namn och ålder som samlas in och lägger dem i variabler som samlas i listan
        {
            Namn = namn;
            Ålder = ålder;
        }

    }





    class Buss
    {

        public int antal_passagerare = 0;//sätter antal passageraresom stigit på bussen till 0 så det är lätt att kolla om användaren fyllt i den eller inte
        public List<Passagerare> passagerare = new List<Passagerare>();//listan skapas






        public void Run()//Metoden som innehåller menyn
        {
            Console.WriteLine("\n\t-----VÄLKOMMEN!-----");//dessa två rader välkommnar användaren och visas inte igen även fast de kommer till menyn igen
            Console.WriteLine("  Till den fantastiska buss simulatorn");

            int val = 0;//valen från menyn återgår alltid till 0 när man kommer tillbaka
            do
            {
                Console.WriteLine("\n\t  --MENY--");//Skriver ut alla valen och vilken siffra man ska skriva in för valet
                Console.WriteLine("  [1] Skriv in passagerare");
                Console.WriteLine("  [2] Passagerarinformation");
                Console.WriteLine("  [3] Totala åldern");
                Console.WriteLine("  [4] Genomsnittliga åldern");
                Console.WriteLine("  [5] Den äldsta passageraren");
                Console.WriteLine("  [6] Hitta en ålder");
                Console.WriteLine("  [7] Sortera bussen");
                Console.WriteLine("  [8] Avsluta programmet");

                Console.Write("\nSkriv in en siffra från menyn och tryck ENTER: ");//Vad användaren ska göra
                int.TryParse(Console.ReadLine(), out val);//Skriver in en siffra. Om siffran inte finns med eller
                                                          //de skriver in bokstäver får de defualt och får skriva in igen

                switch (val)
                {
                    case 1:
                        Add_Passenger();//om användaren skriver 1 skickas de till metoden Add_Passenger
                        break;//loopen avbryts

                    case 2:
                        Print_Buss(passagerare);
                        break;

                    case 3:
                        Calc_Total_Age(passagerare);
                        break;

                    case 4:
                        Calc_Average_Age(passagerare);
                        break;

                    case 5:
                        Max_Age(passagerare);
                        break;

                    case 6:
                        Find_Age(passagerare);
                        break;

                    case 7:
                        Sort_Buss(passagerare);
                        break;

                    case 8:
                        Console.Clear();//gör "rent" på skärmen, menyn försvinner
                        Console.WriteLine("\nAvslutar...");
                        return;//återvänder till Main string och hamnar i slutet av programmet

                    default:
                        Console.Clear();
                        Console.WriteLine("\n  Felaktig inmatning. Skriv in igen");
                        break;//de får skriva in igen, skickas tillbaka att skriva in en siffra



                }
            } while (val != 8);

        }









        //Metod 1 "Skriv in passagerare"
        public void Add_Passenger()
        {

            Console.Clear();//tar bort menyn 

            if (antal_passagerare == 0)//kan bara göra det under if om man inte fyllt i passagerarna förut
            {
                Console.WriteLine("\n  ---Skriv in passagerare---");
                Console.Write("\nHur många passagerare är det: ");//informerar vad de ska göra
                antal_passagerare = 0;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int antal))
                    {
                        if (antal >= 1 || antal <= 25)
                        {
                            antal_passagerare = antal;
                            break;//loopen avbryts och de kommer vidare

                        }
                        else//om de skriver in ett tal mindre än 1, större än 25 hamnar de här och får skriva in en ny siffra
                        {
                            Console.WriteLine("Det måste vara mellan 1 och 25 passagerare");//informerar om vad de gjorde fel
                            Console.Write("Försök igen: ");
                        }

                    }
                    else//om de skriver ett tal med decimaler eller skriver in bokstäver hamnar de här och får skriva in en ny siffra
                    {
                        Console.WriteLine("Ogiltig inmatning. Skriv in en siffra mellan 1 och 25");
                        Console.Write("Försök igen: ");
                    }


                }

                //när loopen avbryts, de kommer hit
                Console.WriteLine("\nSkriv in namn och SEN ålder på alla passagerare");//Tydligt att skriva in namn och sen ålder och inte skriva det i samma

                for (int i = 0; i < antal_passagerare; i++)
                {
                    Console.Write("Namn: ");
                    string name = Console.ReadLine() ?? "";//Skriver in namn som samlas i name och då i listan

                    Console.Write("Ålder: ");
                    if (int.TryParse(Console.ReadLine(), out int age))//Skriver in ålder som samlaśi listan
                    {
                        passagerare.Add(new Passagerare(name, age));//Samlar namnet och åldern i listan med varandra så varje passagerare är sparad med ett namn och ålder

                        //Skrev först detta när det var en vektor
                        //passagerare[i].Namn = name;
                        //passagerare[i].Ålder = age; 

                        //Den kortare verisionen är 
                        //passagerare[i] = new Passagerare(name, age);


                    }
                    else//om de skriver in ålder i decimaler eller med bokstäver hamnar de här
                    {
                        Console.WriteLine("Ogiltig inmatning");
                        Console.Write("Försök igen: ");
                        i--;//tar bort felinmatningen användaren skrivit in
                    }

                }
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");//infromerar användaren vad de ska göra
                Console.ReadKey();
                Console.Clear();//Tar bort så bara menyn syns igen
                return;//återvänder till menyn
            }



            else//Om man redan fyllt i passagerare hamnar man här
            {
                Console.WriteLine("\nDu har redan fyllt i passagerarna");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;
            }

        }









        //Metod 2 "Passagerarinformation"
        public void Print_Buss(List<Passagerare> passagerarelist)
        {

            Console.Clear();
            if (antal_passagerare != 0)//Kan bara se passagerarnas information om man fyllt i passagerarna. != betyder "inte"
            {
                Console.WriteLine("\n  ---Passagerarinformation---");
                Console.WriteLine("\nDet finns {0} passagerare på bussen", antal_passagerare);


                Console.Write("Passagerarna är: ");
                for (int i = 0; i < antal_passagerare; i++)
                {
                    Console.Write(passagerare[i].Namn + " " + passagerare[i].Ålder);//Skriver ut namn och ålder

                    if (i < antal_passagerare - 1)//om listan är mindre än antal_passagerare ta bort 1
                    {
                        Console.Write(", ");//skriver ut ett , mellan passagerarna
                    }

                }
                Console.WriteLine("\nTryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;
            }


            else//Om antal_passagerare fortfarande är 0 hamnar de här
            {
                Console.WriteLine("\nDu måste fylla i \"[1] Skriv in passagerare först\"");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;
            }

        }








        //Metod 3 "Totala åldern"
        public int Calc_Total_Age(List<Passagerare> passagerarelist)
        {

            Console.Clear();
            int total = 0;//Skapar en variabel och sätter den på 0. Om man kör metoden igen kan inte total adderas med den total som fanns innan

            if (antal_passagerare != 0)
            {
                Console.WriteLine("\n  ---Totala åldern---");
                for (int i = 0; i < antal_passagerare; i++)//går igenom listan
                {
                    total = total + passagerare[i].Ålder;//ålder adderas med total och hamnar i total, så för varje ålder i listan blir total större


                }
                Console.WriteLine("\nDen totala åldern är {0} år", total);//Skriver ut den totala åldern
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return total;//För att metoden inte är void måste ett tal också vara med när man åntervänder.
                             //Detta påverkar inte detta program då siffran inte används utanför metoden

            }


            else
            {
                Console.WriteLine("\nDu måste fylla \"[1] Skriv in passagerare\" först");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return 0;//Skriver in 0 när det inte finns något värde att återvända med

            }

        }









        //Metod 4 "Genomsnittliga åldern"
        public double Calc_Average_Age(List<Passagerare> passagerarelist)
        {
            Console.Clear();
            if (antal_passagerare != 0)
            {
                double totalGenomsnitt = 0;//Skapar två nya variabler och sätter dem på 0. De kan då inte adderas om man väljer denna metod igen
                double genomsnitt = 0;//Dem är båda double så de kan använda sig av decimaler
                Console.WriteLine("\n  ---Genomsnittliga åldern---");

                for (int i = 0; i < antal_passagerare; i++)
                {
                    totalGenomsnitt = totalGenomsnitt + passagerare[i].Ålder;//gör samma sak som i Calc_Total_Age

                }


                genomsnitt = totalGenomsnitt / antal_passagerare;//får genomsnittet


                Console.WriteLine("\nDen genomsnittliga åldern är {0:F2} år", genomsnitt);// {0:F2} är en platshållare där bara 2 siffror efter decimalen visas
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return genomsnitt;//för att det inte är en void metod måste den återvända med ett värde

            }



            else
            {
                Console.WriteLine("\nDu måste fylla i \"[1] Skriv in passagerare\" först");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return 0;//återvänder med 0 då genomsnittet inte räknats ut om man inte fyllt i passagerarna

            }


        }








        //Metod 5 "Den äldsta passageraren"
        public int Max_Age(List<Passagerare> passagerarelist)
        {

            Console.Clear();
            if (antal_passagerare != 0)
            {

                int störst = int.MinValue;//int.MinValue är det minsta talet int kan innehålla

                Console.WriteLine("\n  ---Den äldsta passageraren---");

                foreach (Passagerare passagerare in passagerare)//Går igenom alla åldrarna
                {

                    if (passagerare != null && passagerare.Ålder > störst)//om ett tal ät större än "störst" är det de talet som sparas i störst
                    {
                        störst = passagerare.Ålder;

                    }


                }


                foreach (Passagerare passagerare in passagerare)
                {
                    if (störst == passagerare.Ålder)//kollar igeom igen så jag kan visa namnet på den äldsta passageraren också
                    {
                        Console.WriteLine("\nDen äldsta passageraren är {0}, {1} år gammal", passagerare.Namn, störst);
                    }
                }

                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return störst;

            }



            else
            {
                Console.WriteLine("\nDu måste fylla i \"[1] Skriv in passagerare\" först\n");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return 0;
            }


        }







        //Metod 6 "Hitta en ålder"        
        public void Find_Age(List<Passagerare> passagerarelist)
        {


            Console.Clear();
            if (antal_passagerare != 0)
            {
                Console.WriteLine("\n  ---Hitta en ålder---");
                Console.WriteLine("\nSkriv in den yngsta och äldsta ålder du söker efter");

                while (true)//en loop som fortsätter tills "break" används
                {
                    Console.Write("De får vara som yngst: ");
                    if (int.TryParse(Console.ReadLine(), out int minAge))//använder if och TryParse för varje inskrivning av siffror så programmet inte kraschar
                    {
                        Console.Write("De får vara som äldst: ");
                        if (int.TryParse(Console.ReadLine(), out int maxAge))
                        {


                            Console.WriteLine($"De passagerarena mellan {minAge} och {maxAge} år är:");
                            foreach (Passagerare passagerare in passagerare)//Går igenom alla åldrarna och namnen
                            {

                                if (passagerare != null && passagerare.Ålder >= minAge && passagerare.Ålder <= maxAge)//Om åldern är minAge, maxAge eller mellan dem visas passageraren
                                {
                                    Console.WriteLine($"{passagerare.Namn} ({passagerare.Ålder})");

                                }

                            }

                            break;//Bryt loopen

                        }

                        else//om bokstäver elle decimaltal tex skrivit in hamnar de här
                        {
                            Console.WriteLine("\nFelaktig inmatning");
                            Console.WriteLine("Försök igen\n");//Får skriva in igen
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nFelaktig inmatning");
                        Console.WriteLine("Försök igen\n");
                    }



                }
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;

            }




            else
            {
                Console.WriteLine("\nDu måste fylla i \"[1] Skriv in passagerare\" först");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;

            }
        }







        //Metod 7 "Sortera bussen"
        public void Sort_Buss(List<Passagerare> passagerarelist)
        {
            Console.Clear();
            if (antal_passagerare != 0)
            {

                int max = antal_passagerare;//Skapar ny variabler som innehåller siffran på hur många är på bussen

                Console.WriteLine("\n  ---Sortera bussen---");

                //Använder mig av bubblesort. I boken "Programering 1 med C#" av Krister Trangius (2018)
                //på sida 164-167 finns en djupare beskrivning av bubblesort

                for (int i = 0; i < max - 1; i++)
                {
                    //de två for-looparna och max-i-1 gör att den fortsätter sortera tills den är klar

                    for (int j = 0; j < max - i - 1; j++)
                    {
                        if (passagerare[j].Ålder > passagerare[j + 1].Ålder)//om en ålder är större än den andra +1 så byter de plats
                        {

                            Passagerare temp = passagerare[j];//temp är en temporär variabel som lagrar värdet från passagerare[j]
                            passagerare[j] = passagerare[j + 1];//Efter får passagerare[j] samma värde som passagerare[j+1]
                            passagerare[j + 1] = temp;//Har då två värden som är den samma och sätter in en i temp
                            //Värderna har då bytt plats och temp försvninner
                        }
                    }
                }

                //Skriver ut den sorterade listan på passagerarna
                Console.WriteLine("\nSorterat från yngst till äldst");
                for (int i = 0; i < antal_passagerare; i++)
                {
                    Console.WriteLine("{0} år, {1}", passagerare[i].Ålder, passagerare[i].Namn);

                }

                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;

            }
            else
            {
                Console.WriteLine("\nDu måste fylla i \"[1] Skriv in passagerare\" först");
                Console.WriteLine("Tryck ENTER för att komma tillbaka till menyn\n");
                Console.ReadKey();
                Console.Clear();
                return;

            }


        }


    }



    class Program
    {
        public static void Main(string[] args)
        {


            //Det är här koden börjar köra
            //Skapar en buss
            var minbuss = new Buss();
            //Metodanropar Run som finns i budd-objektet. I Run finns menyn
            minbuss.Run();

            //När användaren väljer "Avsluta" i menyn hamnar det sen här. Då är programmet slut
            Console.WriteLine("\nProgrammet avslutas");
            Console.Write("Tryck på ENTER: ");
            Console.ReadKey(true);
        }
    }


}



string input = "";
string time ="0";
int money = 0;
int money2 = 0;
int money3 = 0;
int minutes = 0;


PrintWelcome();
Console.WriteLine($"Parkzeit: {time} minuten");
while(!(input == "d" || input =="D") && (money == 1 || money2 == 1 || money3 == 1 || money == 2 || money2 == 2 || money3 == 2))
{
    EnterCoins();
    AddParkingTime();
}
PintParkingTime();



void PrintWelcome()
{
    Console.WriteLine("Parkautscheinomat: Minnimum 30 min, maximum 90 min");
    Console.WriteLine("Tarif pro Stunde: 1 Euro");
    Console.WriteLine("Zulässige Münzen: 5 cents, 10 cents, 20 cents, 50 cents, 100 (1 euro), 200 (2 euro)");
    Console.WriteLine("Rückgeld ist Freiwillige Spende");
    Console.WriteLine("Parkschein drucken: d oder D");
    Console.WriteLine("");
}

void EnterCoins()
{
    Console.Write("Eingabe (in cent): ");
    input = Console.ReadLine()!;

    if(!(input == "d" || input == "D"))
    {
        money = int.Parse(input);
    }
}

money2 = money3 + money;
money = 0;
minutes = money2 * 6 / 10;
time = string.Format("{0:00}:{1:00}", minutes / 60, minutes % 60);
money3 = money2;
    
void AddParkingTime()
{
    money2 = money3 + money;
    money = 0;
    time = ($"{money2 * 6 / 10}");
    money3 = money2;
    
    if((input=="d"||input=="D") && money2 < 50)
    {
        Console.WriteLine($"Mindesteinwurf 50 Cent, bisher haben Sie {money2} Cent eingeworfen.");
        input =""; money=0;
        
    }
    if(money2 >= 150)
    {
        input = "d";
    }

    else if(!(input == "d" || input =="D"))
    {
        Console.WriteLine($"Parkzeit bisher: {time} Minuten");
    }


}
void PintParkingTime()
{
    if (money2 <= 150) { Console.WriteLine($"\nSie dürfen {time} Stunde(n) parken"); }
    else { Console.WriteLine("\nSie dürfen 1:30 Stunden parken\nDanke für Ihre Spende von {0} EUR {1} Cent", (money2 - 150) / 100, (money2 - 150) % 100); }
}




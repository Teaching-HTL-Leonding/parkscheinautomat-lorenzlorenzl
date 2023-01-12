int coins = 0, coinsNew = 0, coinsOld = 0, minutes = 0;
string Input = "", ParkingTime = string.Format("{0:00}:{1:00}", minutes / 60, minutes % 60);


Console.Clear();
PrintWelcome();
while (!(Input == "d" || Input == "D"))
{
    EnterCoins();
    AddParkingTime();
}
PrintParkingTime();



void PrintWelcome()
{
    Console.WriteLine("Parkscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 90 Minuten");
    Console.WriteLine("Tarif pro Stunde: 1 Euro");
    Console.WriteLine("Zulässige Münzen: 5 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D\n");
}

void EnterCoins()
{
    Console.Write("Ihre Eingabe: ");
    do
    {
        Input = Console.ReadLine()!;
        if (!(Input == "d" || Input == "D" || Input == "5" || Input == "10" || Input == "20" || Input == "50" || Input == "1" || Input == "2"))
        { Console.Write("Ungültiger Einwurf\nIhre Eingabe: "); }
    } while (!(Input == "d" || Input == "D" || Input == "5" || Input == "10" || Input == "20" || Input == "50" || Input == "1" || Input == "2"));

    if (!(Input == "d" || Input == "D")) { coins = int.Parse(Input); }
    if (Input == "1" || Input == "2") { coins = coins * 100; }
}

void AddParkingTime()
{
    coinsNew = coinsOld + coins;
    coins = 0;
    minutes = coinsNew * 6 / 10;
    ParkingTime = string.Format("{0:00}:{1:00}", minutes / 60, minutes % 60);
    coinsOld = coinsNew;

    if ((Input == "d" || Input == "D") && coinsNew < 50)
    {
        Console.WriteLine($"Mindesteinwurf 50 Cent, bisher haben Sie {coinsNew} Cent eingeworfen.");
        Input = ""; coins = 0;
    }
    else if (coinsNew >= 150) { Input = "d"; }
    else if (!(Input == "d" || Input == "D")) { Console.WriteLine("Einwurf bisher: {0},{1} EUR; Parkzeit bisher: {2}", coinsNew / 100, coinsNew % 100, ParkingTime); }
}

void PrintParkingTime()
{
    if (coinsNew <= 150) { Console.WriteLine($"\nSie dürfen {ParkingTime} Stunde(n) parken"); }
    else { Console.WriteLine("\nSie dürfen 1:30 Stunden parken\nDanke für Ihre Spende von {0} EUR {1} Cent", (coinsNew - 150) / 100, (coinsNew - 150) % 100); }
}
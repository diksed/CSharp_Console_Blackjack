var cardGenerator = new Random();
while (true)
{
    Console.WriteLine("Welcome to the C# Console Blackjack game. Please write \"ready\" when you are ready.");
    string command = Console.ReadLine();
    if(command =="ready"|| command == "Ready")
    {
        int pCardOne = GetCard();
        int pCardTwo = GetCard();
        int cCardOne = GetCard();
        int cCardTwo = GetCard();
        int pResult = pCardOne + pCardTwo;
        int cResult = cCardTwo + cCardOne;
        Thread.Sleep(TimeSpan.FromSeconds(1.5));
        Console.WriteLine($"Your First Card : {pCardOne}");
        Thread.Sleep(TimeSpan.FromSeconds(1.5));
        Console.WriteLine($"Dealer's First Card : {cCardOne}");
        Thread.Sleep(TimeSpan.FromSeconds(1.5));
        Console.WriteLine($"Your Second Card : {pCardTwo}");
        Thread.Sleep(TimeSpan.FromSeconds(0.5));
        Console.WriteLine($"Your Hand : {pResult}");
        if(pResult == 21)
        {
            Console.WriteLine("Congratulations, it's blackjack");
        }
        else
        {
            while (true)
            {
                Console.WriteLine("What is your decision? (stand/hit)");
                string decision = Console.ReadLine();
                if (decision == "stand" || decision == "Stand")
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"Dealer's Hand : {cResult}");
                    if (cResult > 21)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine("Congratulations. It's too many, you won!");
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        Console.Clear();
                    }
                    else
                    {
                        if (cResult < 17)
                        {
                            cResult = dealerCards(cResult);
                        }
                        if (cResult > 21)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                            Console.WriteLine("Congratulations. It's too many, you won!");
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            Console.Clear();
                            break;
                        }
                        if (cResult > pResult && cResult < 22)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                            Console.WriteLine("unfortunately, dealer won!");
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            Console.Clear();
                            break;
                        }
                        if (cResult < pResult)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                            Console.WriteLine("Congratulations, you won!");
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            Console.Clear();
                            break;
                        }
                        if (cResult == pResult)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                            Console.WriteLine("It's draw! Good luck in next game.");
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            Console.Clear();
                            break;
                        }
                    }
                }
                if (decision == "hit" || decision == "Hit")
                {
                    pResult = playerCards(pResult);
                    if (pResult > 21)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        Console.WriteLine("Unfortunately, it's too many!");
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        Console.Clear();
                        break;
                    }
                }
            }
            
        }
    }
}

int GetCard()
{
    int newCard = cardGenerator.Next(1, 11);
    return newCard;
}
int dealerCards(int cResult)
{
    while(cResult < 17)
    {
        cResult = cResult + GetCard();
        Thread.Sleep(TimeSpan.FromSeconds(1));
        Console.WriteLine($"Dealer's hand : {cResult}");
    }
    return cResult;
}
int playerCards(int pResult)
{
    pResult = pResult + GetCard();
    Thread.Sleep(TimeSpan.FromSeconds(1));
    Console.WriteLine($"Your hand : {pResult}");
    return pResult;
}

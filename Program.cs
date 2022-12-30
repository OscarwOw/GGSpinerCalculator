
Dictionary<int,bool> Alfa = Enumerable.Range(1, 35).ToDictionary(i => i, i => false);
Dictionary<int,bool> Beta = Enumerable.Range(1, 49).ToDictionary(i => i, i => false);
Dictionary<int,bool> Gamma = Enumerable.Range(1, 83).ToDictionary(i => i, i => false);
Dictionary<int,bool> Gate = Enumerable.Range(1, 10).ToDictionary(i => i, i => false);
Random random = new Random();

int munition = 0;
int xenomit = 0;
int repairCredit = 0;
int GG = 0;
int NH = 0;
int LD = 0;
int Price = 70;
int totalprice = 0;
bool doubler = false;
int reward = 0;
int GateReward = 10000;


void spin()
{
    totalprice += Price;
    int number = random.Next(1, 101);
    if(number <=67) { munition++; }
    if(number >67&&number<=79) { xenomit++; }
    if(number > 79 && number <= 82) { repairCredit++; }
    if(number > 82 && number <= 95) { galaxyGateSpin(); }
    if(number > 95 && number <= 99) { NH++; }
    if(number ==100) { LD++; }

}
void AddGalaxyGatePart(int number)
{
    GG++;
    Gate[number] = true;
    if (isfull())
    {
        RecieveReward();
    }
}
bool isfull()
{
    if (Gate.Values.Where(x => x == false).Count() == 0)
    {
        return true;
    }
    return false;
    
}
void RecieveReward()
{
    reward += GateReward;
    Gate = Enumerable.Range(1, 10).ToDictionary(i => i, i => false);
}

void performspins(int times)
{
    for(int i = 0; i < times; i++)
    {
        spin();
    }
}
void writeAmounts()
{
    Console.WriteLine("Munition: " + munition.ToString());
    Console.WriteLine("Xenomit: " + xenomit.ToString());
    Console.WriteLine("Repair Credits: " + repairCredit.ToString());
    Console.WriteLine("GG: " + GG.ToString());
    Console.WriteLine("NH: " + NH.ToString());
    Console.WriteLine("LD: " + LD.ToString());
    Console.WriteLine("Total Price is: " + totalprice.ToString());
    Console.WriteLine("Total Reward is: " + reward.ToString());
}
void galaxyGateSpin()
{

    int number = random.Next(1, 11);
    if (Gate[number] == false)
    {
        AddGalaxyGatePart(number);
    }
    else
    {
        doubler = true;
        //Console.WriteLine("doubler");
        //TODO doubler

    }
}


performspins(1000);
writeAmounts();




            


Dictionary<string,Dictionary<int,bool>> Gates = new Dictionary<string,Dictionary<int,bool>>();
Dictionary<int,bool> Alfa = Enumerable.Range(1, 34).ToDictionary(i => i, i => false);
Dictionary<int,bool> Beta = Enumerable.Range(1, 48).ToDictionary(i => i, i => false);
Dictionary<int,bool> Gamma = Enumerable.Range(1, 82).ToDictionary(i => i, i => false);
Dictionary<int,bool> Gate = Enumerable.Range(1, 10).ToDictionary(i => i, i => false);
Gates.Add("Alfa",Alfa);
Gates.Add("Beta",Beta);
Gates.Add("Gamma",Gamma);
Random random = new Random();

int munition = 0;
int xenomit = 0;
int repairCredit = 0;
int GG = 0;
int NumberofGGspins = 0;
int NH = 0;
int LD = 0;
int Price = 55;
int totalprice = 0;
bool doubler = false;
int reward = 0;


//spins here
void performspins(int times)
{
    for (int i = 0; i < times; i++)
    {
        spin();
    }
}
void spin()
{
    totalprice += Price;
    int number = random.Next(1, 101);
    if(number <=67) { Munition(); }
    if(number >67&&number<=79) { Xenomit(); }
    if(number > 79 && number <= 82) { RepairCredit(); }
    if(number > 82 && number <= 95) {
        NumberofGGspins++;
        if (doubler)
        {

            galaxyGateDoublerSpin(GalaRandomPart()); 
        }
        else { galaxyGateSpin(GalaRandomPart()); } 
    }
    if(number > 95 && number <= 99) { NanoHull(); }
    if(number ==100) { LogDisk(); }

}
//final writeing
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
    Console.WriteLine("Number of gg spins: " + NumberofGGspins.ToString());
}

//GalaxyGates spins
void galaxyGateDoublerSpin((string,int) pair){

    var list = Gates[pair.Item1].Where(kvp => kvp.Value == false).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    var keys = list.Keys.ToArray();
    doubler = false;
    //Console.WriteLine("you have recieved galaxy gate " + pair.Item1 + " part" + keys[0].ToString() + " via Dubler");
    if (AddGalaxyGatePart((pair.Item1,keys[0])))
    {
        //Console.WriteLine("you have recieved galaxy gate " + pair.Item1 + " part" + keys[1].ToString() + " via Dubler");
        AddGalaxyGatePart((pair.Item1, keys[1]));
    }
}
void galaxyGateSpin((string, int) pair)
{
    if (Gates[pair.Item1][pair.Item2] == false)
    {
        //Console.WriteLine("you have recieved galaxy gate "+ pair.Item1+" part" + pair.Item2.ToString());
        AddGalaxyGatePart(pair);
    }
    else
    {
        doubler = true;
    }
}

bool AddGalaxyGatePart((string,int) pair)
{ 
    GG++;
    Gates[pair.Item1][pair.Item2] = true;    
    if (isfull(pair.Item1))
    {
        RecieveReward(pair.Item1);
        Console.WriteLine("Gate "+pair.Item1 +" Finished");
        return false;        
    }
    return true;
}

//helpers
bool isfull(string gate)
{
    if (Gates[gate].Values.Where(x => x == false).Count() == 0)
    {
        return true;
    }
    return false;    
}
void RecieveReward(string gate)
{
    //TODO rewards
    if(gate == "Alfa")
    {
        Gates["Alfa"] = Enumerable.Range(1, 34).ToDictionary(i => i, i => false);
        reward += 26488;
    }
    if (gate == "Beta")
    {
        Gates["Beta"] = Enumerable.Range(1, 48).ToDictionary(i => i, i => false);
        reward += 52976;
    }
    if (gate == "Gamma")
    {
        Gates["Gamma"] = Enumerable.Range(1, 82).ToDictionary(i => i, i => false);
        reward += 79464;
    }

}

(string,int) GalaRandomPart()
{
    int randomNumber = random.Next(1, 165);
    if (randomNumber < 35)
    {
        return ("Alfa", randomNumber);
    }
    if (randomNumber >= 35 && randomNumber < 83) { 
        return ("Beta", randomNumber - 34);
        }
    return ("Gamma", randomNumber - 82);
}

//otherspins
void Munition()
{
    munition++;
    if (doubler)
    {
        doubler = false;
        munition++;
    }
}
void Xenomit()
{
    xenomit++;
    if (doubler)
    {
        doubler = false;
        xenomit++;
    }
}
void RepairCredit()
{
    repairCredit++;
    if (doubler)
    {
        doubler = false;
        repairCredit++;
    }
}
void NanoHull()
{
    NH++;
    if (doubler)
    {
        doubler = false;
        NH++;
    }
}
void LogDisk()
{
    LD++;
    if (doubler)
    {
        doubler = false;
        LD++;
    }
}


performspins(1000000);
writeAmounts();





            
using System;

class Program
{
    // Funktio ihmispelaajalle (Pelaaja 1)
    static int Pelaaja1Ottaa(int jaljella)
    {
        int maara;

        while (true)
        {
            Console.Write("Pelaaja 1, kuinka monta papua otat? (1-3): ");
            maara = int.Parse(Console.ReadLine());

            // Tarkistetaan, että määrä on sallittu
            if (maara >= 1 && maara <= 3 && maara <= jaljella)
            {
                break;
            }
            else
            {
                Console.WriteLine("Virheellinen määrä. Voit ottaa vain 1-3 papua ja enintään niin monta kuin on jäljellä.");
            }
        }

        return maara;
    }

    // Funktio koneelle (Pelaaja 2)
    static int Pelaaja2Ottaa(int jaljella)
    {
        Random rand = new Random();
        int maara = 1; // Oletuksena kone ottaa yhden pavun

        // Tavoitteena jättää neljällä jaollinen määrä papuja jäljelle
        if (jaljella > 4)
        {
            int tavoiteMaara = jaljella % 4;

            if (tavoiteMaara == 0)
            {
                // Jos jäljellä olevien papujen määrä on jo neljällä jaollinen,
                // valitaan satunnaisesti 1-3 papua
                maara = rand.Next(1, 4);
            }
            else
            {
                // Muuten kone ottaa määrän, joka tekee jäljelle jäävän määrän neljällä jaolliseksi
                maara = tavoiteMaara;
            }
        }
        else
        {
            // Jos papuja on vähemmän kuin 4, kone ottaa kaikki mutta ei yli 3
            maara = jaljella == 4 ? 3 : jaljella;
        }

        Console.WriteLine("Pelaaja 2 (kone) ottaa " + maara + " pavun/papua.");
        return maara;
    }

    static void Main()
    {
        int pavut = 15;  // Alussa papujen määrä

        Console.WriteLine("Tervetuloa papupeliin!");
        Console.WriteLine("Papuja on alussa " + pavut + ".");

        while (pavut > 0)
        {
            // Pelaaja 1 (ihmiskäyttäjä) ottaa papuja
            int pelaaja1Ottaa = Pelaaja1Ottaa(pavut);
            pavut -= pelaaja1Ottaa;
            Console.WriteLine("Papuja jäljellä: " + pavut);

            // Tarkistetaan, hävisikö Pelaaja 1
            if (pavut <= 0)
            {
                Console.WriteLine("Pelaaja 1 hävisi, koska joutui ottamaan viimeisen pavun!");
                break;
            }

            // Pelaaja 2 (kone) ottaa papuja
            int pelaaja2Ottaa = Pelaaja2Ottaa(pavut);
            pavut -= pelaaja2Ottaa;
            Console.WriteLine("Papuja jäljellä: " + pavut);

            // Tarkistetaan, hävisikö Pelaaja 2
            if (pavut <= 0)
            {
                Console.WriteLine("Pelaaja 2 (kone) hävisi, koska joutui ottamaan viimeisen pavun!");
                break;
            }
        }
    }
}


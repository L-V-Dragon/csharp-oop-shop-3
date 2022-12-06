using csharp_oop_shop_3;
using csharp_oop_shop_3.CostumeExceptions;

try
{
    Caramella goleador = new Caramella("Goleador", "Una buona caramella", 0.10, 22, "frutta", 30);
    Console.WriteLine(goleador.GetNumeroKcalorie());
    goleador.StampaProdotto();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Videogioco Pokemon = new Videogioco("Pokémon Scarlatto", "L'ultimo gioco dei Pokemon", 60.00, 22, "GameFreak");
    Pokemon.StampaProdotto();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Sacchetto_di_frutta sacchettoArance = new Sacchetto_di_frutta("Arance", "Un sacchetto di arance", 1.60, 4, 4, 1, "Arancia");
    sacchettoArance.StampaProdotto();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Prodotto lavatriceBosch = new Prodotto("Lavatrice Bosch LD2022", 150.00, 22);
    lavatriceBosch.StampaProdotto();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Acqua Bottiglia1 = new Acqua("Sant'Anna", "Acqua Minerale", 0.20f, 22, 1.5f, 6.9f, "Sant'Anna");
    Console.WriteLine(Acqua.convertiInGalloni(Bottiglia1.GetLitri()));
    Bottiglia1.StampaProdotto();
}
catch (noLitri e)
{
    Console.WriteLine(e.Message);
}
catch (noSorgenteEx e)
{
    Console.WriteLine(e.Message);
}
catch (phException e)
{
    Console.WriteLine(e.Message);
}
catch (litriOverflow e)
{
    Console.WriteLine(e.Message);
}


//foreach (Prodotto articolo in scaffaliNegozio)
//{


//    switch (articolo)
//    {
//        case Caramella:
//            Caramella caramella = (Caramella)articolo;
//            Console.WriteLine(caramella.GetNumeroKcalorie());
//            break;
//        case Videogioco:
//            Videogioco videogioco = (Videogioco)articolo;
//            Console.WriteLine(videogioco.GetStudioDiSviluppo());
//            break;
//    }
//    articolo.StampaProdotto();

//}
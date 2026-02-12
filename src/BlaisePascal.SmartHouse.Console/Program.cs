using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Gambling;
using BlaisePascal.SmartHouse.Domain.Heat;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.Security;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BlaisePascal.SmartHouse.App
{
    class Program
    {
        // --- DISPOSITIVI ---
        static Thermostat termostato;

        // Illuminazione: lista generale che può contenere Lamp ed EcoLamp
        static List<Lamp> lamps = new();

        // MatrixLed (singolo esempio)
        static MatrixLed matrixLed;

        // Sicurezza
        static Door portaIngresso;
        static RollerShutter tapparella;
        static CCTV telecamera;

        static void Main(string[] args)
        {
            InizializzaCasa();

            bool esci = false;
            while (!esci)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== SMART HOUSE CONTROL PANEL ===");
                Console.ResetColor();
                Console.WriteLine("1. Gestione Illuminazione (Lamp, EcoLamp, Matrix)");
                Console.WriteLine("2. Gestione Sicurezza (Door, Shutter, CCTV)");
                Console.WriteLine("3. Gestione Termostato");
                Console.WriteLine("4. Casino");
                Console.WriteLine("5. Esci");
                Console.Write("\nSeleziona modulo: ");

                switch (Console.ReadLine())
                {
                    case "1": MenuIlluminazione(); break;
                    case "2": MenuSicurezza(); break;
                    case "3": MenuTermostato(); break;
                    case "4": MenuCasino(); break;
                    case "5": esci = true; break;
                    default: break;
                }
            }
        }

        static void InizializzaCasa()
        {
            // Termostato
            termostato = new Thermostat(new CurrentTemperature(19), new TargetTemperature(21), false, new CurrentTemperature(15), new CurrentTemperature(25));
            termostato.SetName(new Name("Termostato Main"));
            termostato.SetexternalTemperature(new CurrentTemperature(10));

            // Illuminazione: inizializziamo qualche lampada di esempio
            var lamp1 = new Lamp(false, 50, false, 60, new Hour(18), new Hour(23));
            lamp1.SetName(new Name("Lampada Salotto"));
            lamps.Add(lamp1);

            var eco1 = new EcoLamp(false, 100, true, 10, new Hour(4), new Hour(20), new Hour(6));
            eco1.SetName(new Name("Luce Eco Corridoio"));
            lamps.Add(eco1);

            // Matrix
            matrixLed = new MatrixLed(4, 4, new Led("White", 0));
            matrixLed.SetName(new Name("Wall LED"));

            // Sicurezza
            portaIngresso = new Door(false, true, 1234); // Chiusa, Bloccata, PIN 1234
            portaIngresso.SetName(new Name("Porta Ingresso"));

            tapparella = new RollerShutter(false, 0); // Chiusa
            tapparella.SetName(new Name("Tapparella Studio"));

            telecamera = new CCTV(true, new Hour(22), new Hour(7)); // Accesa
            telecamera.SetName(new Name("CCTV Esterna"));
        }

        #region MENU ILLUMINAZIONE
        static void MenuIlluminazione()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- ILLUMINAZIONE ---");
                Console.ResetColor();
                Console.WriteLine("1. Lista lampade");
                Console.WriteLine("2. Aggiungi lampada");
                Console.WriteLine("3. Rimuovi lampada");
                Console.WriteLine("4. Gestisci Matrix LED");
                Console.WriteLine("5. Indietro");

                string s = Console.ReadLine();
                switch (s)
                {
                    case "1": ListaLampade(); break;
                    case "2": AggiungiLampadaInteractive(); break;
                    case "3": RimuoviLampadaInteractive(); break;
                    case "4": GestioneMatrix(); break;
                    case "5": back = true; break;
                }
            }
        }

        static void ListaLampade()
        {
            Console.Clear();
            Console.WriteLine("--- ELENCO LAMPADE ---");
            if (lamps.Count == 0)
            {
                Console.WriteLine("Nessuna lampada registrata.");
            }
            else
            {
                for (int i = 0; i < lamps.Count; i++)
                {
                    var L = lamps[i];
                    string tipo = L is EcoLamp ? "EcoLamp" : "Lamp";
                    Console.WriteLine($"{i}. [{tipo}] {L.getName()} | Stato: {(L.isOn ? "ON" : "OFF")} | Lum: {L.getBrightness().Value}% | Colore: {L.getColor()}");
                }

                Console.WriteLine("\nSeleziona indice per gestire (invio per tornare): ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int idx) && idx >= 0 && idx < lamps.Count)
                {
                    if (Confirm($"Vuoi gestire '{lamps[idx].getName()}'?")) GestioneLamp(lamps[idx]);
                }
            }
            Console.WriteLine("Premi un tasto per tornare...");
            Console.ReadKey();
        }

        static void AggiungiLampadaInteractive()
        {
            Console.Clear();
            Console.WriteLine("--- AGGIUNGI LAMPADA ---");
            Console.WriteLine("Tipo: 1) Standard  2) EcoLamp");
            var tipo = Console.ReadLine();
            try
            {
                Console.Write("Nome: ");
                var nome = Console.ReadLine() ?? "Lamp";
                bool isOn = ReadBool("Accesa all'avvio? (s/n):");
                int brightness = (int)ReadDoubleAsNumber("Brightness (0-100):");
                bool wireless = ReadBool("Wireless? (s/n):");
                int consumption = (int)ReadDoubleAsNumber("Consumo (W):");
                int onHour = (int)ReadDoubleAsNumber("Ora ON (0-23):");
                int offHour = (int)ReadDoubleAsNumber("Ora OFF (0-23):");

                if (tipo == "1")
                {
                    var lamp = new Lamp(isOn, brightness, wireless, consumption, new Hour(onHour), new Hour(offHour));
                    lamp.SetName(new Name(nome));
                    lamps.Add(lamp);
                    Console.WriteLine("Lampada standard aggiunta.");
                }
                else
                {
                    int maxTime = (int)ReadDoubleAsNumber("Max time on (ore):");
                    var eco = new EcoLamp(isOn, brightness, wireless, consumption, new Hour(maxTime), new Hour(onHour), new Hour(offHour));
                    eco.SetName(new Name(nome));
                    lamps.Add(eco);
                    Console.WriteLine("EcoLamp aggiunta.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore creazione lampada: {ex.Message}");
            }
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        static void RimuoviLampadaInteractive()
        {
            Console.Clear();
            Console.WriteLine("--- RIMUOVI LAMPADA ---");
            for (int i = 0; i < lamps.Count; i++)
            {
                var L = lamps[i];
                string tipo = L is EcoLamp ? "EcoLamp" : "Lamp";
                Console.WriteLine($"{i}. [{tipo}] {L.getName()}");
            }
            Console.Write("Indice da rimuovere: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < lamps.Count)
            {
                if (Confirm($"Sei sicuro di rimuovere '{lamps[idx].getName()}'?"))
                {
                    var removed = lamps[idx];
                    lamps.RemoveAt(idx);
                    Console.WriteLine($"Rimossa: {removed.getName()}");
                }
                else Console.WriteLine("Operazione annullata.");
            }
            else
            {
                Console.WriteLine("Indice non valido.");
            }
            Console.WriteLine("Premi un tasto per tornare...");
            Console.ReadKey();
        }

        // Metodo unico per gestire sia Lamp che EcoLamp (polimorfismo)
        static void GestioneLamp(Lamp lamp)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"GESTIONE: {lamp.getName()}");
                Console.WriteLine($"Tipo: {(lamp is EcoLamp ? "EcoLamp" : "Lamp")}");
                Console.WriteLine($"Stato: {(lamp.isOn ? "ON" : "OFF")}");
                Console.WriteLine($"Luminosità: {lamp.getBrightness().Value}");
                Console.WriteLine($"Colore: {lamp.getColor()}");
                Console.WriteLine($"Orari Auto: {lamp.lightOnSpecificTime.Value}:00 - {lamp.lightOffSpecificTime.Value}:00");
                if (lamp is EcoLamp eco) Console.WriteLine($"[ECO] Max Time On: {eco.maxTimeOn.Value} ore");

                Console.WriteLine("\nAzioni:");
                Console.WriteLine("1. Accendi (TurnOn)");
                Console.WriteLine("2. Spegni (TurnOff)");
                Console.WriteLine("3. Imposta Luminosità");
                Console.WriteLine("4. Cambia Colore");
                Console.WriteLine("5. Applica Schedule Automatica (Orario attuale)");
                if (lamp is EcoLamp) Console.WriteLine("6. Esegui Controllo Eco (EcoActivation)");
                Console.WriteLine("0. Indietro");

                string scelta = Console.ReadLine();
                try
                {
                    bool modified = false;
                    switch (scelta)
                    {
                        case "1":
                            if (Confirm("Procedere con Accensione?")) { lamp.TurnOn(); modified = true; Console.WriteLine("Accesa."); }
                            break;
                        case "2":
                            if (Confirm("Procedere con Spegnimento?")) { lamp.TurnOff(); modified = true; Console.WriteLine("Spenta."); }
                            break;
                        case "3":
                            Console.Write("Valore (0-100): ");
                            int val = int.Parse(Console.ReadLine());
                            if (Confirm($"Impostare luminosità a {val}%?")) { lamp.setBrightness(new Brigthness(val)); modified = true; Console.WriteLine("Luminosità impostata."); }
                            break;
                        case "4":
                            Console.WriteLine("Scegli: 1. RED, 2. GREEN, 3. BLUE, 4. WHITE");
                            string c = Console.ReadLine();
                            Color chosen = c == "1" ? Color.RED : c == "2" ? Color.GREEN : c == "3" ? Color.BLUE : Color.WHITE;
                            if (Confirm($"Cambiare colore in {chosen}?")) { lamp.setColor(chosen); modified = true; Console.WriteLine("Colore impostato."); }
                            break;
                        case "5":
                            if (Confirm("Eseguire schedule ora?")) { lamp.ApllyScheduleNow(); Console.WriteLine($"Controllo orario eseguito. Ora: {DateTime.Now.Hour}. Stato aggiornato."); modified = true; }
                            break;
                        case "6":
                            if (lamp is EcoLamp ecoLamp)
                            {
                                if (Confirm("Eseguire EcoActivation?")) { ecoLamp.EcoActivation(); Console.WriteLine("Controllo risparmio energetico eseguito."); modified = true; }
                            }
                            break;
                        case "0": back = true; continue;
                    }

                    if (modified)
                    {
                        // dopo ogni modifica chiedi se continuare o tornare indietro
                        if (!Confirm("Vuoi effettuare un'altra modifica su questo dispositivo?")) { back = true; }
                        else { /* rimani nel loop */ }
                    }
                    else
                    {
                        Console.WriteLine("Nessuna modifica effettuata.");
                        if (!Confirm("Vuoi effettuare un'altra operazione su questo dispositivo?")) { back = true; }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nERRORE: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }

        static void GestioneMatrix()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("--- MATRIX LED ---");
                Console.WriteLine("1. Accendi Tutto");
                Console.WriteLine("2. Spegni Tutto");
                Console.WriteLine("3. Pattern Scacchiera");
                Console.WriteLine("4. Visualizza");
                Console.WriteLine("0. Indietro");

                string s = Console.ReadLine();
                bool modified = false;
                switch (s)
                {
                    case "1":
                        if (Confirm("Accendere tutti i LED?")) { matrixLed.SwitchOnAll(); modified = true; Console.WriteLine("Tutti i LED accesi."); }
                        break;
                    case "2":
                        if (Confirm("Spegnere tutti i LED?")) { matrixLed.SwitchOffAll(); modified = true; Console.WriteLine("Tutti i LED spenti."); }
                        break;
                    case "3":
                        if (Confirm("Applicare pattern scacchiera?")) { matrixLed.patternCheckerboard(); modified = true; Console.WriteLine("Pattern applicato."); }
                        break;
                    case "4":
                        for (int i = 0; i < matrixLed.matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixLed.matrix.GetLength(1); j++)
                            {
                                Console.Write(matrixLed.GetLed(i, j).isOn ? " [O] " : " [ ] ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "0": back = true; break;
                }

                if (modified)
                {
                    if (!Confirm("Vuoi fare un'altra modifica sulla matrice?")) back = true;
                }
                else if (!back)
                {
                    if (!Confirm("Vuoi fare un'altra operazione sulla matrice?")) back = true;
                }
            }
        }
        #endregion

        #region MENU SICUREZZA
        static void MenuSicurezza()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--- SICUREZZA ---");
                Console.ResetColor();
                Console.WriteLine("1. Porta Principale");
                Console.WriteLine("2. Tapparella");
                Console.WriteLine("3. CCTV");
                Console.WriteLine("4. Indietro");

                switch (Console.ReadLine())
                {
                    case "1": GestisciDoor(); break;
                    case "2": GestisciShutter(); break;
                    case "3": GestisciCCTV(); break;
                    case "4": back = true; break;
                }
            }
        }

        static void GestisciDoor()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine($"\n--- {portaIngresso.getName()} ---");
                Console.WriteLine($"Aperta: {portaIngresso.isOpen} | Bloccata: {portaIngresso.isLocked}");

                Console.WriteLine("A. Apri (TurnOn)");
                Console.WriteLine("B. Chiudi (TurnOff)");
                Console.WriteLine("C. Blocca (LockDoor)");
                Console.WriteLine("D. Sblocca (UnlockDoor)");
                Console.WriteLine("0. Indietro");

                string op = Console.ReadLine().ToUpper();
                try
                {
                    bool modified = false;
                    switch (op)
                    {
                        case "A":
                            if (Confirm("Aprire la porta?")) { portaIngresso.TurnOn(); Console.WriteLine("Porta aperta con successo."); modified = true; }
                            break;
                        case "B":
                            if (Confirm("Chiudere la porta?")) { portaIngresso.TurnOff(); Console.WriteLine("Porta chiusa."); modified = true; }
                            break;
                        case "C":
                            if (Confirm("Bloccare la porta?")) { portaIngresso.LockDoor(); Console.WriteLine("Porta bloccata a chiave."); modified = true; }
                            break;
                        case "D":
                            Console.Write("Inserisci codice sblocco: ");
                            int code = int.Parse(Console.ReadLine());
                            if (Confirm("Procedere sblocco?")) { portaIngresso.UnlockDoor(code); Console.WriteLine("Porta sbloccata."); modified = true; }
                            break;
                        case "0": back = true; continue;
                    }

                    if (modified)
                    {
                        if (!Confirm("Vuoi effettuare un'altra modifica su questa porta?")) back = true;
                    }
                    else
                    {
                        if (!Confirm("Vuoi effettuare un'altra operazione sulla porta?")) back = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERRORE DOMINIO: {ex.Message}");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        static void GestisciShutter()
        {
                                bool back = false;
            while (!back)
            {
                Console.WriteLine($"\n--- {tapparella.getName()} ---");
                Console.WriteLine($"Stato: {(tapparella.isOpen ? "Aperta" : "Chiusa")} | Posizione: {tapparella.ShutterPosition}%");

            Console.WriteLine("A. Alza tutto (TurnOn)");
            Console.WriteLine("B. Abbassa tutto (TurnOff)");
            Console.WriteLine("C. Imposta %");

            try
            {
                string k = Console.ReadLine().ToUpper();
                if (k == "A" && Confirm("Alzare la tapparella al 100%?")) tapparella.TurnOn();
                else if (k == "B" && Confirm("Abbassare la tapparella al 0%?")) tapparella.TurnOff();
                else if (k == "C")
                {
                    Console.Write("Percentuale: ");
                    var p = int.Parse(Console.ReadLine());
                    if (Confirm($"Impostare posizione a {p}%?")) tapparella.ShutterPosition = p;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void GestisciCCTV()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine($"\n--- {telecamera.getName()} ---");
                Console.WriteLine($"Stato: {(telecamera.isOn ? "REGISTRAZIONE ATTIVA" : "STANDBY")}");
                Console.WriteLine($"Orari Auto: {telecamera.turnOnHour.Value} - {telecamera.turnOffHour.Value}");

                Console.WriteLine("A. Accendi Manuale");
                Console.WriteLine("B. Spegni Manuale");
                Console.WriteLine("C. Applica Automazione Oraria");
                Console.WriteLine("0. Indietro");

                string k = Console.ReadLine().ToUpper();
                bool modified = false;
                if (k == "A" && Confirm("Accendere la CCTV?")) { telecamera.TurnOn(); modified = true; Console.WriteLine("CCTV accesa."); }
                else if (k == "B" && Confirm("Spegnere la CCTV?")) { telecamera.TurnOff(); modified = true; Console.WriteLine("CCTV spenta."); }
                else if (k == "C" && Confirm("Applicare automazione oraria?")) { telecamera.AutomaticSwicthOn(); modified = true; Console.WriteLine($"Automazione eseguita. Ora PC: {DateTime.Now.Hour}. Stato: {telecamera.isOn}"); }
                else if (k == "0") { break; }

                if (modified)
                {
                    if (!Confirm("Vuoi effettuare un'altra modifica su questa CCTV?")) break;
                }
                else
                {
                    if (!Confirm("Vuoi effettuare un'altra operazione sulla CCTV?")) break;
                }
            }
        }
        #endregion

        #region MENU TERMOSTATO & CASINO
        static void MenuTermostato()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"--- {termostato.getName()} ---");
                Console.WriteLine($"Temp attuale: {termostato.CurrentTemperature.Value}°C | Target: {termostato.TargetTemperature.Value}°C");
                Console.WriteLine($"Soglia On (ext)<= {termostato.atWhatExternalTemperatureTurnAutomaticalyOn?.Value}°C | Soglia Off (ext)>= {termostato.atWhatExternalTemperatureTurnAutomaticalyOff?.Value}°C");
                Console.WriteLine("1. Imposta Target\n2. Accendi/Spegni\n3. Simula Temp Esterna e controlli automatici\n4. Indietro");
                var sel = Console.ReadLine();
                bool modified = false;
                switch (sel)
                {
                    case "1":
                        Console.Write("Nuova T (5-30): ");
                        if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double t))
                        {
                            if (Confirm($"Impostare Target a {t}°C?"))
                            {
                                termostato.SetTargetTemperature(new TargetTemperature(t));
                                Console.WriteLine($"Target impostato a {termostato.TargetTemperature.Value}°C");
                                modified = true;
                            }
                        }
                        break;
                    case "2":
                        if (Confirm(termostato.IsOn ? "Spegnere il termostato?" : "Accendere il termostato?"))
                        {
                            if (termostato.IsOn) termostato.TurnOff(); else termostato.TurnOn();
                            Console.WriteLine($"Stato corrente: IsOn={termostato.IsOn}, CurrentTemp={termostato.CurrentTemperature.Value}°C");
                            modified = true;
                        }
                        break;
                    case "3":
                        Console.Write("Temp Esterna: ");
                        if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double ext))
                        {
                            if (Confirm($"Impostare temperatura esterna a {ext}°C e applicare automazioni?"))
                            {
                                termostato.SetexternalTemperature(new CurrentTemperature(ext));
                                termostato.CheckAndApplyAutomatic();
                                Console.WriteLine($"Stato after auto: IsOn={termostato.IsOn}, Current={termostato.CurrentTemperature.Value}°C");
                                modified = true;
                            }
                        }
                        break;
                    case "4":
                        back = true;
                        break;
                }

                if (modified)
                {
                    if (!Confirm("Vuoi effettuare un'altra modifica sul termostato?")) back = true;
                }
                else if (!back)
                {
                    if (!Confirm("Vuoi effettuare un'altra operazione sul termostato?")) back = true;
                }
            }
        }

        static void MenuCasino()
        {
            Console.Clear();
            Console.WriteLine("--- CASINO ---");
            Console.Write("Quanto scommetti? ");
            if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0) return;

            Console.WriteLine("1. Roulette\n2. BlackJack\n3. Slot\n4. Russian Roulette");
            string g = Console.ReadLine();

            try
            {
                switch (g)
                {
                    case "1":
                        Roulette r = new Roulette(bet);
                        Console.Write("Numero (1-36): ");
                        int n = int.Parse(Console.ReadLine());
                        int win = r.PlayNumber(n);
                        Console.WriteLine(win > 0 ? $"Vinto: {win}" : "Perso.");
                        break;
                    case "2":
                        BlackJack bj = new BlackJack(bet);
                        Console.WriteLine(bj.Play() > 0 ? "BlackJack Vinto!" : "Banco vince.");
                        break;
                    case "3":
                        Slot s = new Slot(bet);
                        Console.WriteLine(s.playSlot() > 0 ? "Jackpot!" : "Riprova.");
                        break;
                    case "4":
                        RussianRoulette rr = new RussianRoulette(bet);
                        Console.WriteLine(rr.PlayRussianRoulette(true, 1) > 0 ? "Vivo!" : "Morto.");
                        break;
                }
                Console.ReadKey();
            }
            catch (Exception ex) { Console.WriteLine("Errore: " + ex.Message); Console.ReadKey(); }
        }
        #endregion

        #region HELPERS
        private static double ReadDoubleAsNumber(string hint)
        {
            while (true)
            {
                Console.Write($"{hint} ");
                var s = Console.ReadLine();
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var d))
                    return d;
                if (double.TryParse(s, out d))
                    return d;
                Console.WriteLine("Numero non valido.");
            }
        }

        private static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " ");
                var input = Console.ReadLine()?.Trim().ToLowerInvariant();
                if (input == "s" || input == "y" || input == "yes" || input == "si") return true;
                if (input == "n" || input == "no") return false;
                Console.WriteLine("Rispondi con 's' o 'n'.");
            }
        }

        private static bool Confirm(string prompt)
        {
            Console.Write($"{prompt} (s/n): ");
            var input = Console.ReadLine()?.Trim().ToLowerInvariant();
            return input == "s" || input == "y" || input == "si";
        }
        #endregion
    }
}
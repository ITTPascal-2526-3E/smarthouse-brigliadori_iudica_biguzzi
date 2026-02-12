using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Gambling;
using BlaisePascal.SmartHouse.Domain.Heat;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.Security;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Threading;

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

        // CASINO - session state
        static int casinoBalance = 1000;
        static List<string> casinoHistory = new();

        static void Main(string[] args)
        {
            InizializzaCasa();

            bool esci = false;
            while (!esci)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║      SMART HOUSE CONTROL PANEL         ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("[1] Gestione Illuminazione (Lamp, EcoLamp, Matrix)");
                Console.WriteLine("[2] Gestione Sicurezza (Door, Shutter, CCTV)");
                Console.WriteLine("[3] Gestione Termostato");
                Console.WriteLine("[4] Casino");
                Console.WriteLine("[5] Esci");
                Console.WriteLine("[6] Mostra tutti i dispositivi");
                Console.WriteLine();
                Console.Write("Premi il tasto corrispondente... ");

                switch (ReadMenuKey())
                {
                    case "1": Console.Clear(); MenuIlluminazione(); break;
                    case "2": Console.Clear(); MenuSicurezza(); break;
                    case "3": Console.Clear(); MenuTermostato(); break;
                    case "4": Console.Clear(); MenuCasino(); break;
                    case "5": esci = true; break;
                    case "6": Console.Clear(); VisualizzaTuttiDispositivi(); break;
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
                Console.WriteLine("╔═════════ ILLUMINAZIONE ═════════");
                Console.ResetColor();
                Console.WriteLine("[1] Lista lampade");
                Console.WriteLine("[2] Aggiungi lampada");
                Console.WriteLine("[3] Rimuovi lampada");
                Console.WriteLine("[4] Gestisci Matrix LED");
                Console.WriteLine("[5] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string s = ReadMenuKey();
                switch (s)
                {
                    case "1": Console.Clear(); ListaLampade(); break;
                    case "2": Console.Clear(); AggiungiLampadaInteractive(); break;
                    case "3": Console.Clear(); RimuoviLampadaInteractive(); break;
                    case "4": Console.Clear(); GestioneMatrix(); break;
                    case "5": back = true; break;
                }
            }
        }

        static void ListaLampade()
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO LAMPADE ===");
            if (lamps.Count == 0)
            {
                Console.WriteLine("Nessuna lampada registrata.");
                Console.WriteLine("\nPremi un tasto per tornare...");
                Console.ReadKey(true);
                return;
            }

            for (int i = 0; i < lamps.Count; i++)
            {
                var L = lamps[i];
                string tipo = L is EcoLamp ? "EcoLamp" : "Lamp";
                Console.WriteLine($"{i}. [{tipo}] {L.getName()} | Stato: {(L.isOn ? "ON" : "OFF")} | Lum: {L.getBrightness().Value}% | Colore: {L.getColor()}");
            }

            Console.WriteLine();
            Console.Write("Indice per gestire o invio per tornare: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int idx) && idx >= 0 && idx < lamps.Count)
            {
                Console.Clear();
                GestioneLamp(lamps[idx]);
            }
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
            Console.ReadKey(true);
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
            Console.Write("Indice da rimuovere (o invio per tornare): ");
            var raw = Console.ReadLine();
            if (!int.TryParse(raw, out int idx) || idx < 0 || idx >= lamps.Count)
            {
                return;
            }

            var removed = lamps[idx];
            lamps.RemoveAt(idx);
            Console.WriteLine($"Rimossa: {removed.getName()}");
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(true);
        }

        // Metodo unico per gestire sia Lamp che EcoLamp (polimorfismo)
        static void GestioneLamp(Lamp lamp)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"--- GESTIONE: {lamp.getName()} ---");
                Console.WriteLine($"Tipo: {(lamp is EcoLamp ? "EcoLamp" : "Lamp")}");
                Console.WriteLine($"Stato: {(lamp.isOn ? "ON" : "OFF")}");
                Console.WriteLine($"Luminosità: {lamp.getBrightness().Value}");
                Console.WriteLine($"Colore: {lamp.getColor()}");
                Console.WriteLine($"Orari Auto: {lamp.lightOnSpecificTime.Value}:00 - {lamp.lightOffSpecificTime.Value}:00");
                if (lamp is EcoLamp eco) Console.WriteLine($"[ECO] Max Time On: {eco.maxTimeOn.Value} ore");

                Console.WriteLine();
                Console.WriteLine("[1] Accendi (TurnOn)");
                Console.WriteLine("[2] Spegni (TurnOff)");
                Console.WriteLine("[3] Imposta Luminosità");
                Console.WriteLine("[4] Cambia Colore");
                Console.WriteLine("[5] Applica Schedule Automatica (Orario attuale)");
                if (lamp is EcoLamp) Console.WriteLine("[6] Esegui Controllo Eco (EcoActivation)");
                Console.WriteLine("[0] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string scelta = ReadMenuKey();
                switch (scelta)
                {
                    case "1":
                        lamp.TurnOn();
                        break;
                    case "2":
                        lamp.TurnOff();
                        break;
                    case "3":
                        Console.Write("Valore (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int val))
                        {
                            lamp.setBrightness(new Brigthness(val));
                        }
                        break;
                    case "4":
                        Console.WriteLine("Scegli: 1. RED, 2. GREEN, 3. BLUE, 4. WHITE");
                        string c = Console.ReadLine();
                        Colors chosen = c == "1" ? Colors.RED : c == "2" ? Colors.GREEN : c == "3" ? Colors.BLUE : Colors.WHITE;
                        lamp.setColor(chosen);
                        break;
                    case "5":
                        lamp.ApllyScheduleNow();
                        break;
                    case "6":
                        if (lamp is EcoLamp ecoLamp)
                        {
                            ecoLamp.EcoActivation();
                        }
                        break;
                    case "0": back = true; continue;
                    default: break;
                }

                // dopo ogni azione rinfresca automaticamente (nessuna conferma)
                // loop continua e la console viene cancellata in cima alla iterazione
            }
        }

        static void GestioneMatrix()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("--- MATRIX LED ---");
                Console.WriteLine("[1] Accendi Tutto");
                Console.WriteLine("[2] Spegni Tutto");
                Console.WriteLine("[3] Pattern Scacchiera");
                Console.WriteLine("[4] Visualizza");
                Console.WriteLine("[0] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string s = ReadMenuKey();
                switch (s)
                {
                    case "1":
                        matrixLed.SwitchOnAll();
                        break;
                    case "2":
                        matrixLed.SwitchOffAll();
                        break;
                    case "3":
                        matrixLed.patternCheckerboard();
                        break;
                    case "4":
                        Console.Clear();
                        for (int i = 0; i < matrixLed.matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixLed.matrix.GetLength(1); j++)
                            {
                                Console.Write(matrixLed.GetLed(i, j).isOn ? " [O] " : " [ ] ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("\nPremi un tasto per tornare...");
                        Console.ReadKey(true);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        break;
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
                Console.WriteLine("╔══════ SICUREZZA ══════");
                Console.ResetColor();
                Console.WriteLine("[1] Porta Principale");
                Console.WriteLine("[2] Tapparella");
                Console.WriteLine("[3] CCTV");
                Console.WriteLine("[4] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string k = ReadMenuKey();
                switch (k)
                {
                    case "1":
                        Console.Clear();
                        GestisciDoor(); // quando entri nella gestione della porta la console è già pulita
                        break;
                    case "2":
                        Console.Clear();
                        GestisciShutter();
                        break;
                    case "3":
                        Console.Clear();
                        GestisciCCTV();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        break;
                }
            }
        }

        static void GestisciDoor()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"\n--- {portaIngresso.getName()} ---");
                Console.WriteLine($"Aperta: {portaIngresso.isOpen} | Bloccata: {portaIngresso.isLocked}");
                Console.WriteLine();
                Console.WriteLine("[A] Apri (TurnOn)");
                Console.WriteLine("[B] Chiudi (TurnOff)");
                Console.WriteLine("[C] Blocca (LockDoor)");
                Console.WriteLine("[D] Sblocca (UnlockDoor)");
                Console.WriteLine("[0] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string op = ReadMenuKey().ToUpper();
                try
                {
                    switch (op)
                    {
                        case "A":
                            portaIngresso.TurnOn();
                            break;
                        case "B":
                            portaIngresso.TurnOff();
                            break;
                        case "C":
                            portaIngresso.LockDoor();
                            break;
                        case "D":
                            Console.Write("Inserisci codice sblocco: ");
                            if (int.TryParse(Console.ReadLine(), out int code))
                            {
                                portaIngresso.UnlockDoor(code);
                            }
                            break;
                        case "0":
                            back = true;
                            continue;
                        default:
                            break;
                    }

                    // dopo ogni azione si rinfresca automaticamente (loop) senza chiedere conferme
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERRORE DOMINIO: {ex.Message}");
                    Console.ResetColor();
                    Console.ReadKey(true);
                }
            }
        }

        static void GestisciShutter()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"\n--- {tapparella.getName()} ---");
                Console.WriteLine($"Stato: {(tapparella.isOpen ? "Aperta" : "Chiusa")} | Posizione: {tapparella.ShutterPosition}%");
                Console.WriteLine();
                Console.WriteLine("[A] Alza tutto (TurnOn)");
                Console.WriteLine("[B] Abbassa tutto (TurnOff)");
                Console.WriteLine("[C] Imposta %");
                Console.WriteLine("[0] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                try
                {
                    string k = ReadMenuKey().ToUpper();
                    if (k == "A") tapparella.TurnOn();
                    else if (k == "B") tapparella.TurnOff();
                    else if (k == "C")
                    {
                        Console.Write("Percentuale: ");
                        if (int.TryParse(Console.ReadLine(), out int p))
                        {
                            tapparella.ShutterPosition = p;
                        }
                    }
                    else if (k == "0") back = true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); Console.ReadKey(true); }
            }
        }

        static void GestisciCCTV()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"\n--- {telecamera.getName()} ---");
                Console.WriteLine($"Stato: {(telecamera.isOn ? "REGISTRAZIONE ATTIVA" : "STANDBY")}");
                Console.WriteLine($"Orari Auto: {telecamera.turnOnHour.Value} - {telecamera.turnOffHour.Value}");
                Console.WriteLine();
                Console.WriteLine("[A] Accendi Manuale");
                Console.WriteLine("[B] Spegni Manuale");
                Console.WriteLine("[C] Applica Automazione Oraria");
                Console.WriteLine("[0] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string k = ReadMenuKey().ToUpper();
                if (k == "A") { telecamera.TurnOn(); }
                else if (k == "B") { telecamera.TurnOff(); }
                else if (k == "C") { telecamera.AutomaticSwicthOn(); }
                else if (k == "0") { break; }
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
                Console.WriteLine();
                Console.WriteLine("[1] Imposta Target");
                Console.WriteLine("[2] Accendi/Spegni");
                Console.WriteLine("[3] Simula Temp Esterna e controlli automatici");
                Console.WriteLine("[4] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                var sel = ReadMenuKey();
                switch (sel)
                {
                    case "1":
                        Console.Write("Nuova T (5-30): ");
                        if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double t))
                        {
                            termostato.SetTargetTemperature(new TargetTemperature(t));
                        }
                        break;
                    case "2":
                        if (termostato.IsOn) termostato.TurnOff(); else termostato.TurnOn();
                        break;
                    case "3":
                        Console.Write("Temp Esterna: ");
                        if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double ext))
                        {
                            termostato.SetexternalTemperature(new CurrentTemperature(ext));
                            termostato.AutomaticSwicthOn();
                        }
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        break;
                }

                // ogni modifica effettua refresh automatico (loop)
            }
        }

        static void MenuCasino()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                ShowCasinoHeader();

                Console.WriteLine("[1] Roulette");
                Console.WriteLine("[2] BlackJack");
                Console.WriteLine("[3] Slot");
                Console.WriteLine("[4] Russian Roulette");
                Console.WriteLine("[0] Indietro");
                Console.WriteLine();
                Console.Write("Premi il tasto... ");

                string g = ReadMenuKey();
                switch (g)
                {
                    case "1":
                        Console.Clear();
                        PlayRoulette();
                        break;
                    case "2":
                        Console.Clear();
                        PlayBlackJack();
                        break;
                    case "3":
                        Console.Clear();
                        PlaySlot();
                        break;
                    case "4":
                        Console.Clear();
                        PlayRussianRoulette();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        break;
                }
            }
        }

        static void ShowCasinoHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════ CASINO ══════════");
            Console.ResetColor();
            Console.WriteLine($"Saldo sessione: {casinoBalance} credits");
            Console.WriteLine();
            if (casinoHistory.Count > 0)
            {
                Console.WriteLine("Ultime giocate:");
                int start = Math.Max(0, casinoHistory.Count - 5);
                for (int i = start; i < casinoHistory.Count; i++)
                {
                    Console.WriteLine($" - {casinoHistory[i]}");
                }
                Console.WriteLine();
            }
        }

        static void PlayRoulette()
        {
            Console.WriteLine("--- ROULETTE ---");
            Console.WriteLine($"Saldo: {casinoBalance}");
            Console.Write("Quanto scommetti? ");
            if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0)
            {
                Console.WriteLine("Scommessa non valida. Torno al menu...");
                Thread.Sleep(800);
                return;
            }
            if (bet > casinoBalance)
            {
                Console.WriteLine("Saldo insufficiente.");
                Thread.Sleep(800);
                return;
            }

            Console.Write("Numero (1-36): ");
            if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > 36)
            {
                Console.WriteLine("Numero non valido. Torno al menu...");
                Thread.Sleep(800);
                return;
            }

            casinoBalance -= bet;
            Console.WriteLine($"\nScommessa accettata: {bet} credits su {number}. Lancio la roulette...");
            // animazione spin
            AnimateSpinNumbers();

            // esegui gioco di dominio e ottieni payout (assunto come int)
            int payout = 0;
            try
            {
                Roulette r = new Roulette(bet);
                payout = r.PlayNumber(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore gioco: {ex.Message}");
            }

            if (payout > 0)
            {
                casinoBalance += payout;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nVINCI: {payout} credits!");
                Console.ResetColor();
                casinoHistory.Add($"Roulette: +{payout - bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHAI PERSO.");
                Console.ResetColor();
                casinoHistory.Add($"Roulette: -{bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }

            Console.WriteLine("\nPremi un tasto per tornare...");
            Console.ReadKey(true);
        }

        static void PlayBlackJack()
        {
            Console.WriteLine("--- BLACKJACK ---");
            Console.WriteLine($"Saldo: {casinoBalance}");
            Console.Write("Quanto scommetti? ");
            if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0)
            {
                Console.WriteLine("Scommessa non valida. Torno al menu...");
                Thread.Sleep(800);
                return;
            }
            if (bet > casinoBalance)
            {
                Console.WriteLine("Saldo insufficiente.");
                Thread.Sleep(800);
                return;
            }

            casinoBalance -= bet;
            Console.WriteLine($"\nScommessa accettata: {bet} credits. Distribuzione carte...");
            AnimateDealing();

            int payout = 0;
            try
            {
                BlackJack bj = new BlackJack(bet);
                payout = bj.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore gioco: {ex.Message}");
            }

            if (payout > 0)
            {
                casinoBalance += payout;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nVINCI: {payout} credits!");
                Console.ResetColor();
                casinoHistory.Add($"BlackJack: +{payout - bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHAI PERSO.");
                Console.ResetColor();
                casinoHistory.Add($"BlackJack: -{bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }

            Console.WriteLine("\nPremi un tasto per tornare...");
            Console.ReadKey(true);
        }

        static void PlaySlot()
        {
            Console.WriteLine("--- SLOT ---");
            Console.WriteLine($"Saldo: {casinoBalance}");
            Console.Write("Quanto scommetti? ");
            if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0)
            {
                Console.WriteLine("Scommessa non valida. Torno al menu...");
                Thread.Sleep(800);
                return;
            }
            if (bet > casinoBalance)
            {
                Console.WriteLine("Saldo insufficiente.");
                Thread.Sleep(800);
                return;
            }

            casinoBalance -= bet;
            Console.WriteLine($"\nScommessa accettata: {bet} credits. Giro i rulli...");
            AnimateSlot();

            int payout = 0;
            try
            {
                Slot s = new Slot(bet);
                payout = s.playSlot();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore gioco: {ex.Message}");
            }

            if (payout > 0)
            {
                casinoBalance += payout;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nJACKPOT: {payout} credits!");
                Console.ResetColor();
                casinoHistory.Add($"Slot: +{payout - bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNESSUNA COMBINAZIONE. Perso.");
                Console.ResetColor();
                casinoHistory.Add($"Slot: -{bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }

            Console.WriteLine("\nPremi un tasto per tornare...");
            Console.ReadKey(true);
        }

        static void PlayRussianRoulette()
        {
            Console.WriteLine("--- RUSSIAN ROULETTE ---");
            Console.WriteLine($"Saldo: {casinoBalance}");
            Console.Write("Quanto scommetti? ");
            if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0)
            {
                Console.WriteLine("Scommessa non valida. Torno al menu...");
                Thread.Sleep(800);
                return;
            }
            if (bet > casinoBalance)
            {
                Console.WriteLine("Saldo insufficiente.");
                Thread.Sleep(800);
                return;
            }

            casinoBalance -= bet;
            Console.WriteLine($"\nScommessa accettata: {bet} credits. Preparati...");
            AnimateClick();

            int payout = 0;
            bool survived = false;
            try
            {
                RussianRoulette rr = new RussianRoulette(bet);
                payout = rr.PlayRussianRoulette(true, 1); // si suppone ritorni >0 se vivo o 0 se morto
                survived = payout > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore gioco: {ex.Message}");
            }

            if (survived)
            {
                casinoBalance += payout;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSei vivo: ottieni {payout} credits!");
                Console.ResetColor();
                casinoHistory.Add($"RussianRoulette: +{payout - bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSei morto: perdi la scommessa.");
                Console.ResetColor();
                casinoHistory.Add($"RussianRoulette: -{bet} (scommessa {bet}) -> saldo {casinoBalance}");
            }

            Console.WriteLine("\nPremi un tasto per tornare...");
            Console.ReadKey(true);
        }

        // Simple animations to make the game flow clearer
        static void AnimateSpinNumbers()
        {
            Random rnd = new();
            for (int i = 0; i < 16; i++)
            {
                int n = rnd.Next(1, 37);
                Console.Write($"\r... {n}   ");
                Thread.Sleep(70 + i * 5);
            }
            Console.WriteLine("\r               ");
        }

        static void AnimateDealing()
        {
            string[] frames = { "Distribuzione.", "Distribuzione..", "Distribuzione..." };
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"\r{frames[i % frames.Length]}");
                Thread.Sleep(120);
            }
            Console.WriteLine("\r                  ");
        }

        static void AnimateSlot()
        {
            string[] reels = { "🍒  🍋  🍊", "🍋  🍊  🍒", "🍊  🍒  🍋", "🍒  🍒  🍒" };
            for (int i = 0; i < 12; i++)
            {
                Console.Write($"\r{reels[i % reels.Length]}");
                Thread.Sleep(120);
            }
            Console.WriteLine("\r                 ");
        }

        static void AnimateClick()
        {
            Console.Write("Click");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.WriteLine();
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

        // Legge un singolo tasto (non richiede invio). Non mostra il carattere e non stampa "Scelta".
        private static string ReadMenuKey()
        {
            var key = Console.ReadKey(true);
            char c = key.KeyChar;
            return c.ToString();
        }

        private static bool Confirm(string prompt)
        {
            Console.Write($"{prompt} (s/n): ");
            var input = Console.ReadLine()?.Trim().ToLowerInvariant();
            return input == "s" || input == "y" || input == "si";
        }
        #endregion

        #region UTILITY - VISUALIZZA TUTTI I DISPOSITIVI
        static void VisualizzaTuttiDispositivi()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== LISTA COMPLETA DISPOSITIVI ===");
            Console.ResetColor();
            Console.WriteLine();

            // Lampade
            Console.WriteLine("-- Illuminazione --");
            if (lamps.Count == 0) Console.WriteLine("Nessuna lampada.");
            else
            {
                for (int i = 0; i < lamps.Count; i++)
                {
                    var L = lamps[i];
                    string tipo = L is EcoLamp ? "EcoLamp" : "Lamp";
                    Console.WriteLine($"[{i}] {tipo} - {L.getName()} | Stato: {(L.isOn ? "ON" : "OFF")} | Lum: {L.getBrightness().Value}% | Colore: {L.getColor()}");
                }
            }
            Console.WriteLine();

            // Matrix
            Console.WriteLine("-- Matrix LED --");
            if (matrixLed == null) Console.WriteLine("Nessuna matrix definita.");
            else
            {
                int rows = matrixLed.matrix.GetLength(0);
                int cols = matrixLed.matrix.GetLength(1);
                int onCount = 0;
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        if (matrixLed.GetLed(r, c).isOn) onCount++;
                Console.WriteLine($"{matrixLed.getName()} - Dimensioni: {rows}x{cols} | LED accesi: {onCount}/{rows * cols}");
            }
            Console.WriteLine();

            // Sicurezza
            Console.WriteLine("-- Sicurezza --");
            if (portaIngresso != null)
                Console.WriteLine($"Door: {portaIngresso.getName()} | Aperta: {portaIngresso.isOpen} | Bloccata: {portaIngresso.isLocked}");
            if (tapparella != null)
                Console.WriteLine($"RollerShutter: {tapparella.getName()} | Posizione: {tapparella.ShutterPosition}% | Stato: {(tapparella.isOpen ? "Aperta" : "Chiusa")}");
            if (telecamera != null)
                Console.WriteLine($"CCTV: {telecamera.getName()} | Stato: {(telecamera.isOn ? "ON" : "OFF")} | Orari: {telecamera.turnOnHour.Value} - {telecamera.turnOffHour.Value}");
            Console.WriteLine();

            // Termostato
            Console.WriteLine("-- Termostato --");
            if (termostato != null)
            {
                Console.WriteLine($"{termostato.getName()} | Current: {termostato.CurrentTemperature.Value}°C | Target: {termostato.TargetTemperature.Value}°C | IsOn: {termostato.IsOn}");
                Console.WriteLine($"Soglia On (ext)<= {termostato.atWhatExternalTemperatureTurnAutomaticalyOn?.Value}°C | Soglia Off (ext)>= {termostato.atWhatExternalTemperatureTurnAutomaticalyOff?.Value}°C");
            }
            else Console.WriteLine("Nessun termostato definito.");

            Console.WriteLine();
            Console.WriteLine("Premi un tasto per tornare al menu...");
            Console.ReadKey(true);
        }
        #endregion
    }
}
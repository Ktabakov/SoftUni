using MilitaryElite.Models;
using System;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, ISoldier> soldiersbyId = new Dictionary<string, ISoldier>();

            while (input != "End")
            {
                string[] parts = input.Split();

                string type = parts[0];
                string id = parts[1];
                string firstName = parts[2];
                string lastName = parts[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    soldiersbyId[id] = (new Private(id, firstName, lastName, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    ILieutenantGeneral liutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < parts.Length; i++)
                    {
                        string privateId = parts[i];

                        if (!soldiersbyId.ContainsKey(privateId))
                        {
                            continue;
                        }

                        liutenantGeneral.AddPrivate((IPrivate)soldiersbyId[privateId]);
                    }

                    soldiersbyId[id] = (ISoldier)liutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(parts[4]);

                   bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engeneer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string part = parts[i];
                        int hoursWorked = int.Parse(parts[i + 1]);

                        IRepair repair = new Repair(part, hoursWorked);

                        engeneer.Add(repair);
                    }

                    soldiersbyId[id] = engeneer;
                }
                else if (type == nameof(Comando))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    Comando comando = new Comando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string codeName = parts[i];
                        string state = parts[i + 1];

                        bool isMisionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMisionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);

                        comando.AddMission(mission);

                        soldiersbyId[id] = comando;
                    }

                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(parts[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersbyId[id] = spy;
                }

                input = Console.ReadLine();
            }

            foreach (var item in soldiersbyId.Values)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

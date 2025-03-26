using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool runing = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        Console.WriteLine("Bienvenido a mi lista de Contactes");

        while (runing)
        {
            Console.WriteLine();
            Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos     3. Buscar Contactos     
4. Modificar Contacto     5. Eliminar Contacto     6. Salir");
            Console.WriteLine("Digite el número de la opción deseada");

            int typeOption = Convert.ToInt32(Console.ReadLine());

            switch (typeOption)
            {
                case 1:
                    {
                        // Se mantiene el llamado al método para agregar contacto.
                        AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    }
                    break;
                case 2: // Visualizar contactos
                    {
                        Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                        Console.WriteLine($"____________________________________________________________________________________________________________________________");
                        foreach (var id in ids)
                        {
                            var isBestFriend = bestFriends[id];
                            string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                        }
                    }
                    break;
                case 3: // Buscar contacto
                    {
                        SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    }
                    break;
                case 4: // Modificar contacto
                    {
                        ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    }
                    break;
                case 5: // Eliminar contacto
                    {
                        DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    }
                    break;
                case 6:
                    runing = false;
                    break;
                default:
                    Console.WriteLine("Tu eres o te haces el idiota?");
                    break;
            }
        }
    }

    // Método para agregar un nuevo contacto (se mantiene igual al original)
    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);
    }

    // Método para buscar contactos por nombre o apellido
    static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre o parte del mismo a buscar:");
        string searchTerm = Console.ReadLine().ToLower();
        bool found = false;

        Console.WriteLine("Resultados de la búsqueda:");
        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(searchTerm) || lastnames[id].ToLower().Contains(searchTerm))
            {
                string isBestFriendStr = bestFriends[id] ? "Si" : "No";
                Console.WriteLine($"{id} - {names[id]} {lastnames[id]} - {addresses[id]} - {telephones[id]} - {emails[id]} - {ages[id]} años - Mejor amigo: {isBestFriendStr}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }

    // Método para modificar la información de un contacto existente
    static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el ID del contacto a modificar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("El contacto no existe.");
            return;
        }

        Console.WriteLine("Seleccione el campo a modificar:");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. Apellido");
        Console.WriteLine("3. Dirección");
        Console.WriteLine("4. Teléfono");
        Console.WriteLine("5. Email");
        Console.WriteLine("6. Edad");
        Console.WriteLine("7. Mejor Amigo");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("Digite el nuevo nombre:");
                names[id] = Console.ReadLine();
                break;
            case 2:
                Console.WriteLine("Digite el nuevo apellido:");
                lastnames[id] = Console.ReadLine();
                break;
            case 3:
                Console.WriteLine("Digite la nueva dirección:");
                addresses[id] = Console.ReadLine();
                break;
            case 4:
                Console.WriteLine("Digite el nuevo teléfono:");
                telephones[id] = Console.ReadLine();
                break;
            case 5:
                Console.WriteLine("Digite el nuevo email:");
                emails[id] = Console.ReadLine();
                break;
            case 6:
                Console.WriteLine("Digite la nueva edad:");
                ages[id] = Convert.ToInt32(Console.ReadLine());
                break;
            case 7:
                Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;
                break;
            default:
                Console.WriteLine("Opción no válida.");
                return;
        }
        Console.WriteLine("Contacto modificado exitosamente.");
    }

    // Método para eliminar un contacto
    static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el ID del contacto a eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("El contacto no existe.");
            return;
        }

        // Se elimina el contacto de la lista y de cada uno de los diccionarios.
        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado exitosamente.");
    }
}

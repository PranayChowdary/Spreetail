using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MultiValueDictionary
{
    public class Program
    {
        public static Dictionary<string, List<String>> map = new Dictionary<string, List<String>>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                string command = input.Split(' ')[0].ToUpper();

                string arguments = input.Substring(input.IndexOf(' ') + 1);
                string[] values = arguments.Split(' ');

                switch (command)
                {
                    case "KEYS":
                        Keys();
                        break;
                    case "MEMBERS":
                        Members(values);
                        break;
                    case "ADD":
                        Add(values);
                        break;
                    case "REMOVE":
                        Remove(values);
                        break;
                    case "REMOVEALL":
                        RemoveAll(values);
                        break;
                    case "CLEAR":
                        Clear();
                        break;
                    case "KEYEXISTS":
                        Console.WriteLine(KeyExists(values));
                        break;
                    case "MEMBEREXISTS":
                        Console.WriteLine(MemberExists(values));
                        break;
                    case "ALLMEMBERS":
                        AllMembers();
                        break;
                    case "ITEMS":
                        Items();
                        break;
                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
            }
        }

        public static void Keys()
        {
            try
            {
                int i = 1;
                if (map.Count == 0)
                {
                    Console.WriteLine("Empty set");
                }
                foreach (var item in map.Keys)
                {
                    Console.WriteLine(i + ") " + item);
                    i++;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void Members(string[] values)
        {
            try
            {
                if (values.Length != 1)
                {
                    Console.WriteLine("Invalid Input, please try again...");
                    return;
                }
                int i = 1;
                if (map.ContainsKey(values[0]))
                {
                    List<String> strlist = new List<String>();
                    map.TryGetValue(values[0], out strlist);
                    foreach (string item in strlist)
                    {
                        Console.WriteLine(i + ") " + item);
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR, Key does not exist");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
        public static void Add(string[] values)
        {
            try
            {
                if (values.Length != 2 || values[0] == " ")
                {
                    Console.WriteLine("Invalid Input, please try again...");
                    return;
                }
                List<String> strlist = new List<String>();
                if (values.Length == 2)
                {
                    if (map.ContainsKey(values[0]))
                    {
                        map.TryGetValue(values[0], out strlist);
                        foreach (string str in strlist)
                        {
                            if (str == values[1])
                            {
                                Console.WriteLine("ERROR, member already exists for key");
                                return;
                            }
                        }
                        map.Remove(values[0]);
                    }

                    strlist.Add(values[1]);
                    map.Add(values[0], strlist);
                    Console.WriteLine("Added");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }



        public static void Remove(string[] values)
        {
            try
            {
                if (values.Length != 2)
                {
                    Console.WriteLine("Invalid Input, please try again...");
                    return;
                }
                int flag = 0;
                List<String> strlist = new List<String>();

                if (map.ContainsKey(values[0]))
                {
                    map.TryGetValue(values[0], out strlist);
                    foreach (string item in strlist.ToList())
                    {
                        if (item == values[1])
                        {
                            strlist.Remove(item);
                            if (strlist.Count == 0)
                            {
                                map.Remove(values[0]);
                            }
                            else
                            {
                                map.Remove(values[0]);
                                map.Add(values[0], strlist);
                            }
                            flag = 1;
                            Console.WriteLine("Removed");

                        }
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("ERROR, member does not exist");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR, key does not exist ");
                    return;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public static void RemoveAll(string[] values)
        {
            try
            {
                if (values.Length != 1)
                {
                    Console.WriteLine("Invalid Input, please try again...");
                    return;
                }
                if (map.ContainsKey(values[0]))
                {
                    map.Remove(values[0]);
                    Console.WriteLine("REMOVED");
                }
                else
                {
                    Console.WriteLine("ERROR, key does not exist");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public static void Clear()
        {
            try
            {
                map.Clear();
                Console.WriteLine("Cleared");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public static bool KeyExists(string[] values)
        {
            try
            {
                return map.ContainsKey(values[0]) ? true : false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public static bool MemberExists(string[] values)
        {
            try
            {
                if (map.ContainsKey(values[0]))
                {
                    List<String> strlist = new List<String>();
                    map.TryGetValue(values[0], out strlist);
                    foreach (string item in strlist)
                    {
                        if (item == values[1])
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public static void AllMembers()
        {
            try
            {
                int i = 1;
                if (map.Count == 0)
                {
                    Console.WriteLine("(empty set)");
                    return;
                }

                    foreach (string key in map.Keys)
                    {
                        List<String> strlist = new List<String>();
                        map.TryGetValue(key, out strlist);
                        foreach (string val in strlist)
                        {
                            Console.WriteLine(i + ") " + val);
                            i++;
                        }
                    }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public static void Items()
        {
            try
            {
                int i = 1;
                if (map.Count == 0)
                {
                    Console.WriteLine("(empty set)");
                    return;
                }
                    foreach (string key in map.Keys)
                    {
                        List<String> strlist = new List<String>();
                        map.TryGetValue(key, out strlist);
                        foreach (string val in strlist)
                        {
                            Console.WriteLine(i + ") " + key + " : " + val);
                            i++;
                        }
                    }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}



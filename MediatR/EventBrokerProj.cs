using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRProj
{
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{ sender }: '{ message }'";
            chatLog.Add(s);
            Console.WriteLine($"[{ Name }'s chat session { s }]");
        }

    }

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
                if (p.Name != source)
                    p.Receive(source, message);
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)
                ?.Receive(source, destination);
        }
    }

    public class EventBrokerProj
    {
        public static void Main1()
        {
            var room = new ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(jane);
            room.Join(john);

            john.Say("hi");

        }
    }
}

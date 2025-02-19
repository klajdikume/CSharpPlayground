﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    // serveral people to interact with each other
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
            var abc = typeof(Person).GetType().GetProperties();
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: {message}";
            chatLog.Add(s);
            Console.WriteLine($"[{Name}'s chat session] {s}");
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
            {
                if (p.Name != source)
                {
                    p.Receive(source, message);
                }
            }
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)
                ?.Receive(source, message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var room = new ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hi");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("Hi everyone");

        }
    }

    public interface IEmailService
    {
        void SendEmail(string toAddress, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string toAddress, string subject, string body)
        {
            // Code to send email
        }
    }

    public class MyClass
    {
        private readonly IEmailService _emailService;

        public MyClass(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void DoSomething()
        {
            // Use the email service to send an email
            _emailService.SendEmail("to@example.com", "Subject", "Body");
        }
    }

}

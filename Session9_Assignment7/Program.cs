using System;
using System.Collections.Generic;

namespace Session9_Assignment7
{
    // ==========================================
    // Part 1: Primary Constructor & Records
    // ==========================================

    // Q1: Patient class with C# Primary Constructor
    public class Patient(int id, string fullName, string phoneNumber, string medicalHistory)
    {
        public int Id { get; } = id;
        public string FullName { get; } = fullName;
        public string PhoneNumber { get; } = phoneNumber;
        public string MedicalHistory { get; } = medicalHistory;

        public override string ToString()
        {
            return $"Id: {Id} :: FullName: {FullName} :: PhoneNumber: {PhoneNumber} :: MedicalHistory: {MedicalHistory}";
        }
    }

    // Q3: Positional Record for Patient Dto (exposing only non-sensitive data)
    public record PatientDto(int Id, string FullName, string PhoneNumber);

    // Q4: Static Mapper Class with a private constructor
    // Q4: Mapper Class with a private constructor
    public class PatientMapper
    {
        private PatientMapper() { } // Private constructor to prevent instantiation

        public static PatientDto MapFromModelToDto(Patient patient)
        {
            return new PatientDto(patient.Id, patient.FullName, patient.PhoneNumber);
        }
    }
    // ==========================================
    // Part 2: Singleton Pattern
    // ==========================================

    // Q5: AppLogger Singleton class
    public sealed class AppLogger
    {
        private static AppLogger? _instance;

        private AppLogger() { }

        public static AppLogger GetLogger()
        {
            if (_instance == null)
            {
                _instance = new AppLogger();
            }
            return _instance;
        }
    }

    // ==========================================
    // Part 5: Extension Methods
    // ==========================================

    // Q9: TextHelper static class containing extension methods
    public static class TextHelper
    {
        // Normal static method (Bonus requirement)
        public static bool IsShorterThanStatic(string value, int length)
        {
            return value.Length < length;
        }

        // Extension method for string
        public static bool IsShorterThan(this string value, int length)
        {
            return value.Length < length;
        }

        // Extension method to repeat string
        public static string Repeat(this string value, int times)
        {
            if (times <= 0) return string.Empty;
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < times; i++)
            {
                sb.Append(value);
            }
            return sb.ToString();
        }
    }

    // ==========================================
    // Part 6: Fine Calculator for Unit Testing
    // ==========================================
    public class FineCalculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }

    // ==========================================
    // Program Execution & Demonstration
    // ==========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------
            // Part 1 Demonstration: Patient Class & Record Comparisons
            // -------------------------------------------------------------
            Console.WriteLine("------------------------- Part 1 -------------------------");
            Patient patient01 = new Patient(1, "Ali Ahmed", "0123456789", "Allergic to penicillin");
            Patient patient02 = new Patient(1, "Ali Ahmed", "0123456789", "Allergic to penicillin");

            // Q2.1: GetHashCode comparison for classes
            Console.WriteLine($"Patient 01 HashCode: {patient01.GetHashCode()}");
            Console.WriteLine($"Patient 02 HashCode: {patient02.GetHashCode()}");
            Console.WriteLine($"Are HashCodes equal? {patient01.GetHashCode() == patient02.GetHashCode()}");

            // Q2.2: Equals comparison for classes (Reference equality by default)
            Console.WriteLine($"patient01.Equals(patient02): {patient01.Equals(patient02)}");

            // Q2.3: Assignment effect
            patient01 = patient02;
            Console.WriteLine($"After assignment (patient01 = patient02), Equals result: {patient01.Equals(patient02)}");

            // Q3: PatientDto record comparison
            Console.WriteLine("\n--- PatientDto (Record) Comparisons ---");
            PatientDto dto01 = new PatientDto(1, "Ali Ahmed", "0123456789");
            PatientDto dto02 = new PatientDto(1, "Ali Ahmed", "0123456789");
            Console.WriteLine($"dto01.Equals(dto02): {dto01.Equals(dto02)}");
            Console.WriteLine($"Are record HashCodes equal? {dto01.GetHashCode() == dto02.GetHashCode()}");

            // Q4: Mapper demonstration
            Console.WriteLine("\n--- Patient Mapper ---");
            Patient samplePatient = new Patient(10, "Mona Lisa", "0111222333", "Diabetic");
            PatientDto mappedDto = PatientMapper.MapFromModelToDto(samplePatient);
            Console.WriteLine($"Mapped DTO: {mappedDto}");


            // -------------------------------------------------------------
            // Part 2 Demonstration: Singleton AppLogger
            // -------------------------------------------------------------
            Console.WriteLine("\n------------------------- Part 2 -------------------------");
            AppLogger logger1 = AppLogger.GetLogger();
            AppLogger logger2 = AppLogger.GetLogger();
            AppLogger logger3 = AppLogger.GetLogger();
            AppLogger logger4 = AppLogger.GetLogger();

            Console.WriteLine($"Logger 1 HashCode: {logger1.GetHashCode()}");
            Console.WriteLine($"Logger 2 HashCode: {logger2.GetHashCode()}");
            Console.WriteLine($"Logger 3 HashCode: {logger3.GetHashCode()}");
            Console.WriteLine($"Logger 4 HashCode: {logger4.GetHashCode()}");


            // -------------------------------------------------------------
            // Part 3 Demonstration: var & dynamic
            // -------------------------------------------------------------
            Console.WriteLine("\n------------------------- Part 3 -------------------------");
            // 1. Target-typed new
            Patient pTarget = new(5, "Hassan", "0100000000", "None");
            // 2. Using var
            var pVar = new Patient(6, "Omar", "0122222222", "Asthma");
            // 3. Using dynamic
            dynamic pDynamic = new Patient(7, "Noha", "0155555555", "None");
            Console.WriteLine($"Dynamic Patient ToString: {pDynamic}");


            // -------------------------------------------------------------
            // Part 4 Demonstration: Anonymous Types
            // -------------------------------------------------------------
            Console.WriteLine("\n------------------------- Part 4 -------------------------");
            var doctor01 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25000 };
            var doctor02 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25000 };

            Console.WriteLine($"1. Name: {doctor01.Name}, Specialty: {doctor01.Specialty}");
            Console.WriteLine($"2. HashCodes Equal: {doctor01.GetHashCode() == doctor02.GetHashCode()}");
            Console.WriteLine($"3. Type: {doctor01.GetType()}");
            Console.WriteLine($"4. Equals result: {doctor01.Equals(doctor02)}");
            Console.WriteLine($"5. ToString(): {doctor01}");


            // -------------------------------------------------------------
            // Part 5 Demonstration: Extension Methods
            // -------------------------------------------------------------
            Console.WriteLine("\n------------------------- Part 5 -------------------------");
            bool isShort = "Stethoscope".IsShorterThan(5);
            string repeated = "Ab".Repeat(4);
            Console.WriteLine($"\"Stethoscope\".IsShorterThan(5) = {isShort}");
            Console.WriteLine($"\"Ab\".Repeat(4) = {repeated}");


            // =================================================================
            // Theoretical Questions & Answers (Comments)
            // =================================================================
            /*
             [Part 1 Q&A]
             Q1-Q2: Why are class HashCodes and Equals false for two separate class instances with same values?
             A: By default, reference types (classes) use reference equality. Two separate instances point to different memory addresses, 
                so their default HashCodes and Equals return false unless overridden. When assigned (patient01 = patient02), both variables 
                point to the exact same reference, making Equals return true.

             Q3: What is the difference between class and record equality?
             A: Classes use reference equality by default (comparing memory addresses). Records use value-based structural equality, meaning 
                two separate record instances with identical property values will return true for Equals and have matching HashCodes.

             [Part 2 Q&A]
             Q6: What do you observe when calling AppLogger.GetLogger() four times? Why?
             A: All four references return the exact same HashCode. This happens because the Singleton pattern ensures that the constructor 
                is private and restricts instantiation to a single shared instance managed inside the class.

             [Part 3 Q&A]
             Q7.4: What is the difference between var and dynamic?
             A: 'var' is statically typed at compile-time (Implicit Typing). The compiler determines the exact type from the assigned expression. 
                'dynamic' bypasses compile-time type checking; its members and types are resolved dynamically at run-time.

             [Part 4 Q&A]
             Q8: Compare anonymous-type equality with class equality and record equality.
             A: Anonymous types automatically override Equals and GetHashCode based on their properties (structural equality, similar to records), 
                unlike standard classes which use reference equality by default. However, anonymous types are immutable and scoped only to the method.
            */
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{

    class Student
    {
        public int Rolno;
        public string Name { get; set; }
        public string city { get; set; }

        public string Gender { get; set; }
        public int age { get; set; }
       


        public Student(int Rolno, string Name, string city, string Gender,int age)
        {
            this.Rolno = Rolno;
            this.Name = Name;
            this.city = city;
            this.Gender = Gender;
            this.age = age;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] book = { "English", "Tamil", "MAths", " Sceince" };
            //LINQ Query syntax
            //display all books
            var result = from b in book
                         select b;
            foreach (var bname in result)
            {
                Console.WriteLine(bname);
            }
            Console.WriteLine("---------------------");
            //display books name containing a
            //Query syntax
            var r = from bookname in book
                    where bookname.Contains('a')
                    select bookname;
            foreach (var bname in r)
            {
                Console.WriteLine(bname);
            }
            Console.WriteLine("----------------------Method  syntax");

            //Method syntax
            var r3 = book.Where(s => s.Contains('a'));
            foreach (var bname in r3)
            {
                Console.WriteLine(bname);
            }

            Console.WriteLine("-------------------");
            int[] marks = { 90, 80, 70, 99, 78 };
            Console.WriteLine("Minimum marks:{0}", marks.Min());
            Console.WriteLine("Maximum marks:{0}", marks.Max());
            // nothing here

            
            //marks btw 70 to 100
            //query syntax
            var r1 = from m in marks
                     where m > 70 && m < 100
                     select m;

            foreach (var mrks in r1)
            {
                Console.WriteLine(mrks);
            }
            //method syntax
            Console.WriteLine("------------------------------method syntax");
            var r4 = marks.Where(mr => mr>70 && mr<=100);
            foreach (var mrks in r4)
            {
                Console.WriteLine(mrks);
            }
            Console.WriteLine("--------------------");
            //count no. of marks btw 70 to 100

            var r2 = (from m in marks
                      where m > 70 && m < 100
                      select m).Count();
            Console.WriteLine("No. of marks btw 70 and 100 :{0}", r2);

            List<Student> stu = new List<Student>()
            {
                new Student(1001, "mayank", "abad", "male",22),
                new Student(1002, "mak", "pune", "male",23),
                new Student(1003, "rani", "mumbai", "female",25),
                new Student(1004, "munni", "ahmedabad", "female",27)
            };

            Console.WriteLine("--------------------------------");
            //display max age of student
            //method syntax
            var stude = stu.Max(ss=>ss.age);
            Console.WriteLine("MAx Age:{0}", stude);

            //display name and city where city is pune
            var stucity = from s in stu
                          where s.city.Equals("pune")
                          select new { s.Name, s.city };

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("display name and city where city is pune");
            foreach(var sc in stucity)
            {
                Console.WriteLine(sc.Name + " " + sc.city);
            }
            Console.WriteLine("-------------------------------------");

            //order the info of student based on Gender
            Console.WriteLine("order the info of student based on Gender");

            var stugender = from s in stu
                            orderby s.Gender, s.Name
                            select s;

            foreach(var st in stugender)
            {
                Console.WriteLine(st.Name + "  " +"  "+st.city+"  "+st.Gender);
            }
            Console.WriteLine("------------------------------------------");

            //group by n. of males and females
            Console.WriteLine("group by n. of males and females");
            var stumf = from s in stu
                        group s by s.Gender;

            foreach(var s in stumf)
            {
                Console.WriteLine(s.Key+" "+s.Count());
            }

            //using 


        }
    }
}

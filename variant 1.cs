using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  namespace prac_6_var_1
{
  static class Program
  {
    public static void Main()
    {
      var s1 = new Student();
      Console.WriteLine(s1);

      var s = new Student(new Person("Денис", "Власкин", new DateTime(2001, 2, 4)), Education.Specialist, 21);
      //Console.WriteLine(s.ToShortString());
      //Console.WriteLine("");
      foreach (Education element in Enum.GetValues(typeof(Education)))
        Console.WriteLine($"{element}={s[element]}");

      //Console.WriteLine("");
      //Console.WriteLine(s);
      //Console.WriteLine("");

      s.AddExams(new Exam("Matematika", 2, new DateTime(2019, 2, 2)), new Exam("Linal", 3, new DateTime(2019, 2, 2)), new Exam("Filosofi9", 4, new DateTime(2019, 2, 2)), new Exam("Rysskiy", 5, new DateTime(2019, 2, 2)), new Exam("Matlogika", 3, new DateTime(2019, 2, 2)));
      Console.WriteLine(s);
      Console.WriteLine("");
      Console.ReadLine();
    }
  }
  public class Person
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }

    public int BirthYear
    {
      get => this.Birthday.Year;
      set => this.Birthday = new DateTime(value, this.Birthday.Month, this.Birthday.Day);
    }
    public Person(string name, string surname, DateTime birthday)
    {
      this.Name = name;
      this.Surname = surname;
      this.Birthday = birthday;

    }
    public Person()
    {
      this.Name = "Стандарт";
      this.Surname = "Стандарт";
      this.Birthday = new DateTime(2000, 1, 1);
    }
    public override string ToString() => $"{this.Name}{this.Surname }[{this.Birthday:dd.MM.yy}]";
    public virtual string ToShortString() => $"{this.Name}{this.Surname }";
  }
  public enum Education
  {
    Specialist,
    Bachelor,
    SecondEducation
  }
  public class Exam
  {
    public string Subject { get; set; }
    public int Mark { get; set; }
    public DateTime Date { get; set; }

    public Exam(string subject, int mark, DateTime date)
    {
      this.Subject = subject;
      this.Mark = mark;
      this.Date = date;

    }
    public Exam()
    {
      this.Date = new DateTime(2000, 1, 1);
    }
    public override string ToString() => $"{this.Subject }[{this.Date:dd.MM.yy}]={this.Mark}";
  }

 
  public  class Student
  {
    public Education Education { get; private set; }
    public List<Exam> Exams { get; private set; }
    public int GroupNumber { get; private set; }
    public Person Person { get; private set; }

    public bool this[Education ed] => this.Education == ed;

    public double AverageMark
    {
      get {
        return this.Exams.Any() ? this.Exams.Where(x => ! string.IsNullOrWhiteSpace(x.Subject)).Average(x => x.Mark) : 0;

      }
    }
    public Student(Person person, Education education, int group_number)
    {
      this.Person = person;
      this.Education = education;
      this.GroupNumber = group_number;
      this.Exams = new List<Exam>();
    }
    public Student()
    { 
      this.Person = new Person();
    this.GroupNumber=0;
      this.Exams = new List<Exam>();
      }
  public void AddExams(params Exam[] exams)
  {
    this.Exams.AddRange(exams);
  }
  public override string ToString()
  {
    var sb = new StringBuilder($"{ this.Person.ToShortString()}:");
    sb.AppendLine($"Дата рождения:{this.Person.Birthday}");
    sb.AppendLine($"Группа:{this.GroupNumber}");
    sb.AppendLine($"Образование:{this.Education}");
     sb.AppendLine($"Средняя оценка:{this.AverageMark}");
    sb.AppendLine($"Экзамены:");
    foreach (var exam in this.Exams)
      sb.AppendLine($"{exam}");
    return sb.ToString();
  }
  public virtual string ToShortString()
  {
    var sb = new StringBuilder($"{ this.Person.ToShortString()}:");
    sb.AppendLine($"Дата рождения:{this.Person.Birthday}");
    sb.AppendLine($"Группа:{this.GroupNumber}");
    sb.AppendLine($"Образование:{this.Education}");
    sb.AppendLine($"Средняя оценка:{this.AverageMark}");
    return sb.ToString();

  }
}
}

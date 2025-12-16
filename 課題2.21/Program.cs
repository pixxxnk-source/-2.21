using System;
using System.Collections.Generic;
interface IBillable
{
    int CostForDay(int hoursWorked);
}
abstract class Employee : IBillable
{
    public int Id { get; }
    public string Name { get; }
    protected Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public abstract int CostForDay(int hoursWorked);
}
class FullTimeEmployee : Employee
{
    protected const int HourlyRate = 1250;
    public FullTimeEmployee(int id, string name)
        : base(id, name)
    {
    }
    public override int CostForDay(int hoursWorked)
    {
        if (hoursWorked <= 8)
        {
            return hoursWorked * HourlyRate;
        }
        int regularPay = 8 * HourlyRate;
        int overtimeHours = hoursWorked - 8;
        int overtimePay = (int)(HourlyRate * 1.25) * overtimeHours;

        return regularPay + overtimePay;
    }
}
class ContractEmployee : Employee
{
    protected const int HourlyRate = 1000;
    public ContractEmployee(int id, string name)
        : base(id, name)
    {
    }
    public override int CostForDay(int hoursWorked)
    {
        return hoursWorked * HourlyRate;
    }
}
class Program
{
    static void Main()
    {
        List<IBillable> employees = new List<IBillable>
        {
            new FullTimeEmployee(1, "田中"),
            new ContractEmployee(2, "佐藤")
        };

        int[] hoursWorked = { 9, 9 };

        int index = 0;

        //修正箇所：for→foreach
        foreach (IBillable employee in employees)
        {
            int cost = employee.CostForDay(hoursWorked[index]);
            Console.WriteLine($"日給: {cost}円");
            index++;
        }
    }
}


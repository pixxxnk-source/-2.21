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
    private const int HourlyRate = 1250;

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
    private const int HourlyRate = 1000;

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
    static void Main(string[] args)
    {
        List<IBillable> employees = new List<IBillable>
        {
            new FullTimeEmployee(1, "田中"),
            new ContractEmployee(2, "佐藤")
        };

        int[] hours = { 9, 9 };

        for (int i = 0; i < employees.Count; i++)
        {
            int cost = employees[i].CostForDay(hours[i]);
            Console.WriteLine($"日給: {cost}円");
        }
    }
}

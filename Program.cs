
using SalaryConverter;

var salaryConverter = new SalaryConverterService();

// Convert gross salary to net salary
var grossSalary = 10000000m;
var salary = salaryConverter.ConvertGrossToNet(grossSalary);
Console.WriteLine(salary);


Console.ReadLine();
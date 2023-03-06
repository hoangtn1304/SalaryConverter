namespace SalaryConverter
{
    public class Salary
    {
        public decimal Gross { get; set; }
        public decimal Net { get; set; }
        public decimal SocialInsurance { get; set; }
        public decimal HealthInsurance { get; set; }
        public decimal UnemploymentInsurance { get; set; }
        public decimal PersonalIncomeTax { get; set; }
        public decimal IncomeBeforeTax { get; set; }
        public decimal TaxableIncome { get; set; }

        public override string ToString()
        {
            return
                $"Gross salary: {Gross:0,0}{Environment.NewLine}" +
                $"Social Insurance: {SocialInsurance:-0,0}{Environment.NewLine}" +
                $"Health Insurance: {HealthInsurance:-0,0}{Environment.NewLine}" +
                $"Unemployment Insurance: {UnemploymentInsurance:-0,0}{Environment.NewLine}" +
                $"Income before tax: {IncomeBeforeTax:0,0}{Environment.NewLine}" +
                $"Taxable Income: {TaxableIncome:0,0}{Environment.NewLine}" +
                $"Personal Income Tax: {PersonalIncomeTax:0,0}{Environment.NewLine}" +
                $"Net salary: {Net:0,0}{Environment.NewLine}";
        }
    }
}

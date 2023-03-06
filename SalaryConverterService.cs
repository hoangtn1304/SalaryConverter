namespace SalaryConverter
{
    public class SalaryConverterService
    {
        private const decimal PersonalIncomeTaxRate = 0.05m; // 5% PIT rate
        private const decimal SocialInsuranceRate = 0.08m; // 8% SI rate
        private const decimal HealthInsuranceRate = 0.015m; // 1.5% HI rate
        private const decimal UnemploymentInsuranceRate = 0.01m; // 1% UI rate

        private const decimal MaximumSocialInsuranceAmount = 2200000m; // Maximum SI amount
        private const decimal MaximumHealthInsuranceAmount = 1100000m; // Maximum HI amount
        private const decimal MaxmimumUnemploymentInsuranceAmount = 110000m; // Maximum UI amount

        private const decimal PersonalDeductionAmount = 11000000m; // Personal deduction amount
        private const decimal DependentDeductionAmount = 4400000m; // Depdendent deduction amount

        public Salary ConvertGrossToNet(decimal grossSalary, int dependents = 0)
        {
            decimal socialInsurance = CalculateSocialInsurance(grossSalary);

            decimal healthInsurance = CalculateHealthInsurance(grossSalary);

            decimal unemploymentInsurance = CalculateUnemploymentInsurance(grossSalary);

            decimal incomeBeforeTax = grossSalary - socialInsurance - healthInsurance - unemploymentInsurance;

            decimal taxableIncome = CalculateTaxableIncome(incomeBeforeTax, dependents);

            decimal personalIncomeTax = CalculatePersonalIncomeTax(taxableIncome);

            decimal netSalary = incomeBeforeTax - personalIncomeTax;

            return new Salary
            {
                Gross = grossSalary,
                Net = netSalary,
                HealthInsurance = healthInsurance,
                UnemploymentInsurance = unemploymentInsurance,
                SocialInsurance = socialInsurance,
                PersonalIncomeTax = personalIncomeTax,
                IncomeBeforeTax = incomeBeforeTax,
                TaxableIncome = taxableIncome
            };
        }

        private decimal CalculateUnemploymentInsurance(decimal grossSalary)
        {
            decimal unemploymentInsurance = grossSalary * UnemploymentInsuranceRate;

            unemploymentInsurance = Math.Min(unemploymentInsurance, MaxmimumUnemploymentInsuranceAmount);

            return unemploymentInsurance;
        }

        private decimal CalculateHealthInsurance(decimal grossSalary)
        {
            decimal healthInsurance = grossSalary * HealthInsuranceRate;

            healthInsurance = Math.Min(healthInsurance, MaximumHealthInsuranceAmount);

            return healthInsurance;
        }

        private decimal CalculateSocialInsurance(decimal grossSalary)
        {
            decimal socialInsurance = grossSalary * SocialInsuranceRate;

            socialInsurance = Math.Min(socialInsurance, MaximumSocialInsuranceAmount);

            return socialInsurance;
        }

        private decimal CalculateTaxableIncome(decimal salaryBeforeTax, int dependents)
        {
            decimal personalDeduction = PersonalDeductionAmount + (dependents * DependentDeductionAmount);

            decimal taxableIncome = salaryBeforeTax - personalDeduction;

            return taxableIncome < 0 ? 0 : taxableIncome;
        }

        private decimal CalculatePersonalIncomeTax(decimal taxableIncome)
        {
            decimal personalIncomeTax = taxableIncome * PersonalIncomeTaxRate;

            return personalIncomeTax;
        }
    }
}

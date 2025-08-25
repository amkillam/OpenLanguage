# Complete Integration Example

This document demonstrates a comprehensive real-world example that integrates multiple OpenLanguage components to create a complete document processing application.

## Scenario: Mail Merge Report Generator

This example creates a sophisticated mail merge system that combines formula parsing, field instruction processing, and localization features to generate personalized financial reports.

### Complete Application Structure

```csharp
using OpenLanguage.SpreadsheetML.Formula;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML;
using System;
using System.Collections.Generic;
using System.Linq;

public class FinancialReportGenerator
{
    private readonly LanguageIdentifier _language;
    private readonly List<CustomerData> _customers;

    public FinancialReportGenerator(LanguageIdentifier language)
    {
        _language = language;
        _customers = new List<CustomerData>();
    }

    public void AddCustomer(CustomerData customer) => _customers.Add(customer);

    public DocumentTemplate CreateReportTemplate()
    {
        var template = new DocumentTemplate(_language);

        // Header section with company info and date
        template.AddHeaderFields();

        // Customer address block
        template.AddAddressSection();

        // Financial summary with calculated fields
        template.AddFinancialSummary();

        // Detailed transaction table
        template.AddTransactionTable();

        // Footer with terms and conditions
        template.AddFooterSection();

        return template;
    }

    public void GenerateReports(DocumentTemplate template)
    {
        foreach (var customer in _customers)
        {
            var personalizedDocument = template.PersonalizeForCustomer(customer);
            Console.WriteLine($"Generated report for: {customer.Name}");
            Console.WriteLine(personalizedDocument.ToString());
            Console.WriteLine(new string('=', 80));
        }
    }
}

public class CustomerData
{
    public string Name { get; set; } = "";
    public string Company { get; set; } = "";
    public Address Address { get; set; } = new Address();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public decimal CreditLimit { get; set; }
    public DateTime LastPaymentDate { get; set; }

    public decimal TotalBalance => Transactions.Sum(t => t.Amount);
    public decimal AverageTransaction => Transactions.Any() ? Transactions.Average(t => t.Amount) : 0;
    public int TransactionCount => Transactions.Count;
}

public class Address
{
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public PostalData ZipCode { get; set; } = new PostalData("00000");
    public CountryRegion Country { get; set; } = CountryRegion.UnitedStates;
}

public class Transaction
{
    public DateTime Date { get; set; }
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
}

public enum TransactionType
{
    Sale,
    Payment,
    Credit,
    Adjustment
}
```

### Document Template Builder

```csharp
public class DocumentTemplate
{
    private readonly LanguageIdentifier _language;
    private readonly List<FieldInstruction> _fields;
    private readonly List<Formula> _formulas;

    public DocumentTemplate(LanguageIdentifier language)
    {
        _language = language;
        _fields = new List<FieldInstruction>();
        _formulas = new List<Formula>();
    }

    public void AddHeaderFields()
    {
        // Company name from document properties
        var companyField = new FieldInstruction("DOCPROPERTY");
        companyField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Company"));
        _fields.Add(companyField);

        // Localized date field
        var dateField = CreateLocalizedDateField();
        _fields.Add(dateField);

        // Page numbering
        var pageField = new FieldInstruction("PAGE");
        _fields.Add(pageField);

        var pageTotalField = new FieldInstruction("NUMPAGES");
        _fields.Add(pageTotalField);
    }

    public void AddAddressSection()
    {
        // Customer greeting with name formatting
        var greetingField = new FieldInstruction("GREETINGLINE");
        greetingField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\f"));
        greetingField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, GetLocalizedGreeting()));
        greetingField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\l"));
        greetingField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, GetLocalizedPunctuation()));
        _fields.Add(greetingField);

        // Address block with country-specific formatting
        var addressField = new FieldInstruction("ADDRESSBLOCK");
        addressField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\l"));
        addressField.Arguments.Add(new FieldArgument(FieldArgumentType.Number, ((int)_language).ToString()));
        _fields.Add(addressField);

        // Postal barcode for US addresses
        var barcodeField = CreateConditionalBarcodeField();
        _fields.Add(barcodeField);
    }

    public void AddFinancialSummary()
    {
        // Current balance
        var balanceField = new FieldInstruction("MERGEFIELD");
        balanceField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "TotalBalance"));
        balanceField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\#"));
        balanceField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, GetLocalizedCurrencyFormat()));
        _fields.Add(balanceField);

        // Credit utilization calculation
        var creditUtilizationFormula = FormulaParser.Parse("=TotalBalance/CreditLimit*100");
        _formulas.Add(creditUtilizationFormula);

        // Average transaction amount
        var avgField = new FieldInstruction("MERGEFIELD");
        avgField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "AverageTransaction"));
        avgField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\#"));
        avgField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, GetLocalizedCurrencyFormat()));
        _fields.Add(avgField);

        // Days since last payment
        var daysSincePayment = new FieldInstruction("IF");
        var lastPaymentDate = new FieldInstruction("MERGEFIELD");
        lastPaymentDate.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "LastPaymentDate"));

        daysSincePayment.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, lastPaymentDate));
        daysSincePayment.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "<>"));
        daysSincePayment.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, ""));

        // Calculate days difference
        var daysCalc = new FieldInstruction("DATE");
        daysCalc.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\@"));
        daysCalc.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "d"));

        daysSincePayment.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, daysCalc));
        daysSincePayment.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "No payment recorded"));

        _fields.Add(daysSincePayment);
    }

    public void AddTransactionTable()
    {
        // Database field for transaction details
        var dbField = new FieldInstruction("DATABASE");
        dbField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\d"));
        dbField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "OLEDB;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=transactions.xlsx;"));
        dbField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\s"));
        dbField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "SELECT Date, Description, Amount FROM Transactions WHERE CustomerID = { MERGEFIELD CustomerID }"));
        dbField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\t"));
        dbField.Arguments.Add(new FieldArgument(FieldArgumentType.Number, ((int)DatabaseTableFormat.Professional).ToString()));

        _fields.Add(dbField);
    }

    public void AddFooterSection()
    {
        // Terms and conditions with hyperlink
        var termsLink = new FieldInstruction("HYPERLINK");
        termsLink.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "https://company.com/terms"));
        termsLink.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, GetLocalizedTermsText()));
        termsLink.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\o"));
        termsLink.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "View full terms and conditions"));
        _fields.Add(termsLink);

        // Contact information
        var contactField = new FieldInstruction("DOCPROPERTY");
        contactField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "ContactInfo"));
        _fields.Add(contactField);
    }

    private FieldInstruction CreateLocalizedDateField()
    {
        var dateField = new FieldInstruction("DATE");
        dateField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\@"));

        string dateFormat = _language switch
        {
            LanguageIdentifier.EnglishUS => "MMMM d, yyyy",
            LanguageIdentifier.EnglishUK => "d MMMM yyyy",
            LanguageIdentifier.FrenchFrance => "d MMMM yyyy",
            LanguageIdentifier.GermanGermany => "d. MMMM yyyy",
            LanguageIdentifier.Japanese => "yyyy年MM月dd日",
            _ => "MMMM d, yyyy"
        };

        dateField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, dateFormat));
        return dateField;
    }

    private FieldInstruction CreateConditionalBarcodeField()
    {
        var ifField = new FieldInstruction("IF");

        // Check if country is US
        var countryField = new FieldInstruction("MERGEFIELD");
        countryField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "Country"));

        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, countryField));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "="));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, "UnitedStates"));

        // Create barcode if US
        var barcodeField = new FieldInstruction("BARCODE");
        var zipField = new FieldInstruction("MERGEFIELD");
        zipField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "ZipCode"));

        barcodeField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, zipField));
        barcodeField.Arguments.Add(new FieldArgument(FieldArgumentType.Switch, "\f"));
        barcodeField.Arguments.Add(new FieldArgument(FieldArgumentType.Identifier, "A"));

        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.NestedField, barcodeField));
        ifField.Arguments.Add(new FieldArgument(FieldArgumentType.StringLiteral, ""));

        return ifField;
    }

    private string GetLocalizedGreeting()
    {
        return _language switch
        {
            LanguageIdentifier.EnglishUS or LanguageIdentifier.EnglishUK => "Dear",
            LanguageIdentifier.FrenchFrance => "Cher",
            LanguageIdentifier.GermanGermany => "Liebe",
            LanguageIdentifier.Spanish => "Estimado",
            _ => "Dear"
        };
    }

    private string GetLocalizedPunctuation()
    {
        return _language switch
        {
            LanguageIdentifier.FrenchFrance => " :",
            LanguageIdentifier.GermanGermany => ",",
            _ => ","
        };
    }

    private string GetLocalizedCurrencyFormat()
    {
        return _language switch
        {
            LanguageIdentifier.EnglishUS => "$#,##0.00",
            LanguageIdentifier.EnglishUK => "£#,##0.00",
            LanguageIdentifier.FrenchFrance => "#,##0.00 €",
            LanguageIdentifier.GermanGermany => "#.##0,00 €",
            LanguageIdentifier.Japanese => "¥#,##0",
            _ => "$#,##0.00"
        };
    }

    private string GetLocalizedTermsText()
    {
        return _language switch
        {
            LanguageIdentifier.EnglishUS or LanguageIdentifier.EnglishUK => "Terms and Conditions",
            LanguageIdentifier.FrenchFrance => "Conditions Générales",
            LanguageIdentifier.GermanGermany => "Allgemeine Geschäftsbedingungen",
            LanguageIdentifier.Spanish => "Términos y Condiciones",
            _ => "Terms and Conditions"
        };
    }

    public PersonalizedDocument PersonalizeForCustomer(CustomerData customer)
    {
        var personalizedFields = new List<string>();

        foreach (var field in _fields)
        {
            string personalizedField = PersonalizeField(field, customer);
            personalizedFields.Add(personalizedField);
        }

        var personalizedFormulas = new List<string>();
        foreach (var formula in _formulas)
        {
            string personalizedFormula = PersonalizeFormula(formula, customer);
            personalizedFormulas.Add(personalizedFormula);
        }

        return new PersonalizedDocument(customer, personalizedFields, personalizedFormulas);
    }

    private string PersonalizeField(FieldInstruction field, CustomerData customer)
    {
        // This would typically involve mail merge data binding
        // For demonstration, we'll show the field structure
        return $"Field: {field}";
    }

    private string PersonalizeFormula(Formula formula, CustomerData customer)
    {
        // Replace formula variables with actual customer data
        string formulaText = formula.ToString();

        formulaText = formulaText.Replace("TotalBalance", customer.TotalBalance.ToString());
        formulaText = formulaText.Replace("CreditLimit", customer.CreditLimit.ToString());

        try
        {
            Formula personalizedFormula = FormulaParser.Parse(formulaText);
            return $"Formula: {personalizedFormula} (Original: {formula})";
        }
        catch
        {
            return $"Formula (unparseable): {formulaText}";
        }
    }
}

public class PersonalizedDocument
{
    public CustomerData Customer { get; }
    public List<string> Fields { get; }
    public List<string> Formulas { get; }

    public PersonalizedDocument(CustomerData customer, List<string> fields, List<string> formulas)
    {
        Customer = customer;
        Fields = fields;
        Formulas = formulas;
    }

    public override string ToString()
    {
        var result = new System.Text.StringBuilder();
        result.AppendLine($"FINANCIAL REPORT FOR: {Customer.Name}");
        result.AppendLine($"Company: {Customer.Company}");
        result.AppendLine($"Address: {Customer.Address.Street}, {Customer.Address.City}, {Customer.Address.State} {Customer.Address.ZipCode}");
        result.AppendLine();

        result.AppendLine("FIELDS:");
        foreach (var field in Fields)
        {
            result.AppendLine($"  {field}");
        }

        result.AppendLine();
        result.AppendLine("FORMULAS:");
        foreach (var formula in Formulas)
        {
            result.AppendLine($"  {formula}");
        }

        result.AppendLine();
        result.AppendLine($"Total Balance: ${Customer.TotalBalance:N2}");
        result.AppendLine($"Credit Limit: ${Customer.CreditLimit:N2}");
        result.AppendLine($"Average Transaction: ${Customer.AverageTransaction:N2}");
        result.AppendLine($"Transaction Count: {Customer.TransactionCount}");

        return result.ToString();
    }
}
```

### Usage Example

```csharp
public class Program
{
    public static void Main()
    {
        // Create report generator for US English
        var reportGenerator = new FinancialReportGenerator(LanguageIdentifier.EnglishUS);

        // Add sample customers
        reportGenerator.AddCustomer(CreateSampleCustomer1());
        reportGenerator.AddCustomer(CreateSampleCustomer2());

        // Create document template
        var template = reportGenerator.CreateReportTemplate();

        // Generate personalized reports
        reportGenerator.GenerateReports(template);

        Console.WriteLine("\n" + new string('=', 80));
        Console.WriteLine("FRENCH VERSION");
        Console.WriteLine(new string('=', 80));

        // Generate French version
        var frenchGenerator = new FinancialReportGenerator(LanguageIdentifier.FrenchFrance);
        frenchGenerator.AddCustomer(CreateSampleCustomer1());

        var frenchTemplate = frenchGenerator.CreateReportTemplate();
        frenchGenerator.GenerateReports(frenchTemplate);
    }

    private static CustomerData CreateSampleCustomer1()
    {
        return new CustomerData
        {
            Name = "John Smith",
            Company = "Acme Corporation",
            Address = new Address
            {
                Street = "123 Main Street",
                City = "Anytown",
                State = "CA",
                ZipCode = new PostalData("12345-6789"),
                Country = CountryRegion.UnitedStates
            },
            CreditLimit = 10000m,
            LastPaymentDate = DateTime.Now.AddDays(-15),
            Transactions = new List<Transaction>
            {
                new Transaction { Date = DateTime.Now.AddDays(-30), Description = "Purchase #1001", Amount = 250.50m, Type = TransactionType.Sale },
                new Transaction { Date = DateTime.Now.AddDays(-25), Description = "Purchase #1002", Amount = 175.25m, Type = TransactionType.Sale },
                new Transaction { Date = DateTime.Now.AddDays(-20), Description = "Payment", Amount = -200.00m, Type = TransactionType.Payment },
                new Transaction { Date = DateTime.Now.AddDays(-10), Description = "Purchase #1003", Amount = 89.99m, Type = TransactionType.Sale }
            }
        };
    }

    private static CustomerData CreateSampleCustomer2()
    {
        return new CustomerData
        {
            Name = "Jane Doe",
            Company = "Global Industries",
            Address = new Address
            {
                Street = "456 Business Ave",
                City = "Commerce City",
                State = "NY",
                ZipCode = new PostalData("54321"),
                Country = CountryRegion.UnitedStates
            },
            CreditLimit = 25000m,
            LastPaymentDate = DateTime.Now.AddDays(-5),
            Transactions = new List<Transaction>
            {
                new Transaction { Date = DateTime.Now.AddDays(-45), Description = "Bulk Order #2001", Amount = 1250.00m, Type = TransactionType.Sale },
                new Transaction { Date = DateTime.Now.AddDays(-30), Description = "Payment", Amount = -1000.00m, Type = TransactionType.Payment },
                new Transaction { Date = DateTime.Now.AddDays(-15), Description = "Service Fee", Amount = 45.00m, Type = TransactionType.Sale },
                new Transaction { Date = DateTime.Now.AddDays(-5), Description = "Payment", Amount = -295.00m, Type = TransactionType.Payment }
            }
        };
    }
}
```

### Advanced Features Demonstration

```csharp
public static class AdvancedFeatures
{
    public static void DemonstrateFormulaManipulation()
    {
        Console.WriteLine("=== Formula Manipulation Demo ===");

        // Parse complex financial formulas
        string[] formulas = {
            "=IF(TotalBalance>CreditLimit*0.8,"High Risk","Normal")",
            "=ROUND((TotalBalance/CreditLimit)*100,2)",
            "=VLOOKUP(CustomerID,CreditRatings,2,FALSE)",
            "=SUM(TransactionAmounts)*TaxRate"
        };

        foreach (string formulaText in formulas)
        {
            try
            {
                Formula formula = FormulaParser.Parse(formulaText);
                Console.WriteLine($"✓ Parsed: {formula.AstRoot}");

                // Demonstrate formula reconstruction
                string reconstructed = formula.ToString();
                Console.WriteLine($"  Reconstructed: {reconstructed}");

                // Verify reconstruction by re-parsing
                Formula reparsed = FormulaParser.Parse(reconstructed);
                Console.WriteLine($"  Re-parsed successfully: {reparsed.AstRoot}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error with '{formulaText}': {ex.Message}");
            }
            Console.WriteLine();
        }
    }

    public static void DemonstrateComplexFieldInstructions()
    {
        Console.WriteLine("=== Complex Field Instructions Demo ===");

        // Nested IF with multiple conditions
        string complexIf = "IF { IF { MERGEFIELD Department } = "Sales" { MERGEFIELD SalesTarget } { MERGEFIELD StandardTarget } } > { MERGEFIELD ActualSales } "Target Met" "Below Target"";

        try
        {
            FieldInstruction field = FieldParser.Parse(complexIf);
            Console.WriteLine($"✓ Complex IF parsed: {field}");

            // Analyze nested structure
            int nestedCount = 0;
            foreach (var arg in field.Arguments)
            {
                if (arg.Type == FieldArgumentType.NestedField)
                {
                    nestedCount++;
                    Console.WriteLine($"  Found nested field: {arg.Value}");
                }
            }
            Console.WriteLine($"  Total nested fields: {nestedCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error: {ex.Message}");
        }
    }

    public static void DemonstrateDataValidation()
    {
        Console.WriteLine("=== Data Validation Demo ===");

        // Test postal data validation
        string[] zipCodes = { "12345", "12345-6789", "123456789", "1234", "abcde" };

        foreach (string zip in zipCodes)
        {
            try
            {
                PostalData postal = new PostalData(zip);
                Console.WriteLine($"✓ Valid ZIP: {postal}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"✗ Invalid ZIP: {zip}");
            }
        }

        // Test measurement values
        int[] measurements = { -32, -31, 0, 31, 32 };

        foreach (int measure in measurements)
        {
            try
            {
                PtsMeasurementValue pts = new PtsMeasurementValue(measure);
                Console.WriteLine($"✓ Valid measurement: {pts} points");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"✗ Invalid measurement: {measure} points");
            }
        }
    }
}
```

This comprehensive example demonstrates how all the OpenLanguage components work together to create a sophisticated document processing application with real-world functionality including formula parsing, field instruction processing, data validation, and internationalization support.
